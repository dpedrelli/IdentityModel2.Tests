using IdentityModel.OidcClient.Browser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    public class SystemBrowser : IBrowser
    {
        private readonly int _port;
        private readonly string _path;
        private readonly string _browserPath;

        public SystemBrowser(int port, string path = null, string browserPath = null)
        {
            _port = port;
            _path = path;
            _browserPath = browserPath;
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options)
        {
            using (var listener = new LoopbackHttpListener(_port, _path))
            {
                Process browser = OpenBrowser(options.StartUrl, _browserPath);
                try
                {
                    var result = await listener.WaitForCallbackAsync();
                    
                    // Check if browser returned and not exited.
                    // Close browser window.
                    if ((browser != null) && (!browser.HasExited))
                    {
                        browser.CloseMainWindow();
                        browser.Close();
                    }
                    else if (_browserPath == "microsoft-edge:")
                    {
                        // http://stackoverflow.com/questions/33547279/how-to-open-microsoft-edge-from-c-sharp-and-wait-for-it-to-be-closed
                        //We need to find the most recent MicrosoftEdgeCP process that is active
                        //Process[] edgeProcessList = Process.GetProcessesByName("MicrosoftEdgeCP");
                        //Process newestEdgeProcess = null;
                        //foreach (Process theprocess in edgeProcessList)
                        //{
                        //    if (newestEdgeProcess == null || theprocess.StartTime > newestEdgeProcess.StartTime)
                        //    {
                        //        newestEdgeProcess = theprocess;
                        //    }
                        //}
                        //Process[] list = Process.GetProcessesByName("MicrosoftEdge");
                        //foreach (Process theprocess in list)
                        //{
                        //    theprocess.CloseMainWindow();
                        //    theprocess.Close();
                        //    theprocess.Kill();
                        //}


                        //newestEdgeProcess.Kill();
                        //newestEdgeProcess.CloseMainWindow();
                        //newestEdgeProcess.Close();
                        //newestEdgeProcess.WaitForExit();

                        //http://www.ranorex.com/forum/how-to-close-edge-browser-or-a-tab-t8897.html
                        //IList<Ranorex.WebDocument> AllDoms = Host.Local.FindChildren<Ranorex.WebDocument>();
                        //foreach (WebDocument myDom in AllDoms)
                        //{
                        //    if (myDom.PageUrl.Contains("Google") && myDom.PageUrl.Trim() != "")
                        //    {
                        //        if (myDom.BrowserVersion == "Microsoft Edge")
                        //        {
                        //            repo.MicrosoftEdge.Google.Click();
                        //            Keyboard.Press(System.Windows.Forms.Keys.F4 | System.Windows.Forms.Keys.Control, 62, Keyboard.DefaultKeyPressTime, 1, true);
                        //        }
                        //        else
                        //        {
                        //            myDom.Close();
                        //        }

                        //    }

                        //}

                    }

                    if (String.IsNullOrWhiteSpace(result))
                    {
                        return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = "Empty response." };
                    }

                    return new BrowserResult { Response = result, ResultType = BrowserResultType.Success };
                }
                catch (TaskCanceledException ex)
                {
                    return new BrowserResult { ResultType = BrowserResultType.Timeout, Error = ex.Message };
                }
                catch (Exception ex)
                {
                    return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = ex.Message };
                }
            }
        }

        public static Process OpenBrowser(string url, string browserPath)
        {
            // Return process to allow for closing browser.
            Process result;
            try
            {
                if ((browserPath.Length > 0) && (browserPath == "microsoft-edge:"))
                {
                    result = Process.Start(browserPath + url);
                }
                else if (browserPath.Length > 0)
                {
                    result = Process.Start(browserPath, url);
                }
                else
                {
                    result = Process.Start(url);
                }
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    result = Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    result = Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    result = Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
            return result;
        }
    }

    public class LoopbackHttpListener : IDisposable
    {
        const int DefaultTimeout = 60 * 5; // 5 mins (in seconds)

        IWebHost _host;
        TaskCompletionSource<string> _source = new TaskCompletionSource<string>();
        string _url;

        public string Url => _url;

        public LoopbackHttpListener(int port, string path = null)
        {
            path = path ?? String.Empty;
            if (path.StartsWith("/")) path = path.Substring(1);

            _url = $"http://127.0.0.1:{port}/{path}";

            _host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(_url)
                .Configure(Configure)
                .Build();
            _host.Start();
        }

        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Task.Delay(500);
                _host.Dispose();
            });
        }

        void Configure(IApplicationBuilder app)
        {
            app.Run(async ctx =>
            {
                if (ctx.Request.Method == "GET")
                {
                    SetResult(ctx.Request.QueryString.Value, ctx);
                }
                else if (ctx.Request.Method == "POST")
                {
                    if (!ctx.Request.ContentType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
                    {
                        ctx.Response.StatusCode = 415;
                    }
                    else
                    {
                        using (var sr = new StreamReader(ctx.Request.Body, Encoding.UTF8))
                        {
                            var body = await sr.ReadToEndAsync();
                            SetResult(body, ctx);
                        }
                    }
                }
                else
                {
                    ctx.Response.StatusCode = 405;
                }
            });
        }

        private void SetResult(string value, HttpContext ctx)
        {
            try
            {
                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/html";
                ctx.Response.WriteAsync("<h1>You can now return to the application.</h1>");
                ctx.Response.Body.Flush();

                _source.TrySetResult(value);
            }
            catch
            {
                ctx.Response.StatusCode = 400;
                ctx.Response.ContentType = "text/html";
                ctx.Response.WriteAsync("<h1>Invalid request.</h1>");
                ctx.Response.Body.Flush();
            }
        }

        public Task<string> WaitForCallbackAsync(int timeoutInSeconds = DefaultTimeout)
        {
            Task.Run(async () =>
            {
                await Task.Delay(timeoutInSeconds * 1000);
                _source.TrySetCanceled();
            });

            return _source.Task;
        }
    }

}
