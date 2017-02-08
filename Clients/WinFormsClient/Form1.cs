using IdentityModel.OidcClient;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Helpers;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        private OidcClient _oidcClient;
        private HttpClient _apiClient;

        string _currentAccessToken = "";
        string _currentIdentityToken = "";
        string _currentRefreshToken = "";
        private string currentAccessToken
        {
            get { return _currentAccessToken; }
            set
            {
                _currentAccessToken = value;
                lblAccessToken.Text = "Access Token:  "+ value;
            }
        }
        private string currentIdentityToken
        {
            get { return _currentIdentityToken; }
            set
            {
                _currentIdentityToken = value;
                lblIdentityToken.Text = "Identity Token:  " + value;
            }
        }
        private string currentRefreshToken
        {
            get { return _currentRefreshToken; }
            set
            {
                _currentRefreshToken = value;
                lblRefreshToken.Text = "Refresh Token:  " + value;
            }
        }
         
        List<SiteSettings> sites = new List<SiteSettings>();

        public Form1()
        {
            InitializeComponent();
            sites.Add(new SiteSettings { Description = "None" });

            sites.AddRange(TestSite.GetSites());
            #region IdentityServer Demo site
            sites.AddRange(IdentityServerDemoSite.GetSites());
            #endregion

            initializeDefaultSettings();
            initializeBrowserList();
        }

        private void initializeOidcClient()
        {
            if (_oidcClient != null)
            {
                _oidcClient.Options.Authority = authority;
                _oidcClient.Options.ClientId = clientId;
                _oidcClient.Options.ClientSecret = clientSecret;
                _oidcClient.Options.Scope = scope;
                _oidcClient.Options.RedirectUri = redirectUri;
                return;
                //_oidcClient.Options.Browser = null;
                //_oidcClient = null;
            }
            var options = new OidcClientOptions
            {
                Authority = authority,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = scope,
                RedirectUri = redirectUri,
                FilterClaims = false,
                Browser = new SystemBrowser(port: 7890, path: null, browserPath: internetBrowsers[cboBrowsers.SelectedIndex].Path)
            };
//            var browser = (SystemBrowser)_oidcClient.Options.Browser;

            _oidcClient = new OidcClient(options);
        }

        private void initializeApiClient()
        {
            _apiClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        #region Control Properties
        private string authority { get { return txtAuthority.Text; } set { txtAuthority.Text = value; } }
        private string clientId { get { return txtClientId.Text; } set { txtClientId.Text = value; } }
        private string clientSecret { get { return txtClientSecret.Text; } set { txtClientSecret.Text = value; } }
        private string scope { get { return txtScope.Text; } set { txtScope.Text = value; } }
        private string redirectUri { get { return txtRedirectUri.Text; } set { txtRedirectUri.Text = value; } }
        private string baseAddress { get { return txtBaseAddress.Text; } set { txtBaseAddress.Text = value; } }
        private string resourceEndpoint
        {
            get
            {
                return cboEndpoint.Text;
                //return _txtResourceEndpoint.Text;
            }
            set
            {
                cboEndpoint.Text = value;
                //_txtResourceEndpoint.Text = value;
            }
        }

        private bool allowLogin
        {
            get
            {
                if (authority == "") { return false; }
                if (clientId == "") { return false; }
                if (scope == "") { return false; }
                if (redirectUri == "") { return false; }
                return true;
            }
        }
        private bool allowRefresh
        {
            get
            {
                if (!loginSucceeded) { return false; }
                return true;
            }
        }
        private bool allowCall
        {
            get
            {
                if (!loginSucceeded) { return false; }
                if (baseAddress == "") { return false; }
                return true;
            }
        }

        private bool _loginSucceeded = false;
        private bool loginSucceeded
        {
            get
            {
                return _loginSucceeded;
            }
            set
            {
                _loginSucceeded = value;
                lblLoginStatus.Text = "Login Status:  ";
                if (value)
                {
                    lblLoginStatus.Text += "Succeeded";
                }
                else
                {
                    lblLoginStatus.Text += "Failed";
                }
            }
        }
        #endregion

        private async Task login()
        {
            if (!allowLogin) { return; }
            _apiClient = null;
            initializeOidcClient();
            var result = await _oidcClient.LoginAsync();
            loginSucceeded = !result.IsError;
            if (!result.IsError)
            {
                currentAccessToken = result.AccessToken;
                currentIdentityToken = result.IdentityToken;
                currentRefreshToken = result.RefreshToken;
                txtCallResult.Text = "";
                foreach (Claim claim in result.User.Claims)
                {
                    //txtCallResult.Text += claim.ToString() + "\n\r";
                    txtCallResult.Text += claim.ToString() + Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show(this, result.Error, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task refresh()
        {
            if (!allowRefresh) { return; }
            var refreshResult = await _oidcClient.RefreshTokenAsync(currentRefreshToken);
            if (!refreshResult.IsError)
            {
                currentRefreshToken = refreshResult.RefreshToken;
                currentAccessToken = refreshResult.AccessToken;
            }
        }

        private async Task callApi()
        {
            if (!allowCall) { return; }
            if (_apiClient == null)
            {
                initializeApiClient();
            }
            _apiClient.SetBearerToken(currentAccessToken);
            //_apiClient.SetToken(".AspNetCore.Identity.Application", currentIdentityToken);
            HttpResponseMessage response = null;
            if (rbGet.Checked)
            {
                response = await _apiClient.GetAsync(resourceEndpoint);
            }
            if (response == null) { return; }
            if (response.IsSuccessStatusCode)
            {
                //var json = JArray.Parse(await response.Content.ReadAsStringAsync());
                //txtCallResult.Text = json.ToString();
                txtCallResult.Text = await response.Content.ReadAsStringAsync();
                //MessageBox.Show(this, json.ToString(), "API", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtCallResult.Text = response.ReasonPhrase;
                //MessageBox.Show(this, response.ReasonPhrase, "API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await login();
        }

        private void selectSiteSettings()
        {
            int tabIndex = cboDefaultSettings.SelectedIndex;
            authority = sites[tabIndex].Authority;
            clientId = sites[tabIndex].ClientId;
            clientSecret = sites[tabIndex].ClientSecret;
            scope = sites[tabIndex].Scope;
            redirectUri = sites[tabIndex].RedirectUri;
            baseAddress = sites[tabIndex].BaseAddress;
            cboEndpoint.Items.Clear();
            if (sites[tabIndex].ResourceEndpoints != null)
            {
                foreach (ResourceEndpoint endpoint in sites[tabIndex].ResourceEndpoints)
                {
                    cboEndpoint.Items.Add(endpoint.Endpoint);
                }
                cboEndpoint.SelectedIndex = 0;
            }
        }

        private void selectEndpoint()
        {
            int tabIndex = cboDefaultSettings.SelectedIndex;
            int selectedIndex = cboEndpoint.SelectedIndex;
            resourceEndpoint = sites[tabIndex].ResourceEndpoints[selectedIndex].Endpoint;
            rbGet.Checked = (sites[tabIndex].ResourceEndpoints[selectedIndex].Method == HttpMethod.HttpGet);
            rbPost.Checked = (sites[tabIndex].ResourceEndpoints[selectedIndex].Method == HttpMethod.HttpPost);
        }

        // http://www.rhizohm.net/irhetoric/post/2009/04/03/0a-Finding-All-Installed-Browsers-in-Windows-XP-and-Vista-ndash3b-beware-64bit!0a-.aspx
        //private class InternetBrowser
        //{
        //    public string Name { get; set; }
        //    public string Path { get; set; }
        //    //public string IconPath { get; set; }
        //}
        //private List<InternetBrowser> internetBrowsers = new List<InternetBrowser>();
        private List<InternetBrowser> internetBrowsers;
        private void initializeBrowserList()
        {
            //RegistryKey browserKeys;
            ////on 64bit the browsers are in a different location
            //browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            //if (browserKeys == null)
            //    browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            //string[] browserNames = browserKeys.GetSubKeyNames();

            //InternetBrowser defaultBrowser = new InternetBrowser();
            //defaultBrowser.Name = "Default";
            ////defaultBrowser.IconPath = "";
            //defaultBrowser.Path = "";
            //internetBrowsers.Add(defaultBrowser);

            //for (int i = 0; i < browserNames.Length; i++)
            //{
            //    InternetBrowser browser = new InternetBrowser();
            //    RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
            //    browser.Name = (string)browserKey.GetValue(null);
            //    RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
            //    browser.Path = (string)browserKeyPath.GetValue(null);
            //    //RegistryKey browserIconPath = browserKey.OpenSubKey(@"DefaultIcon");
            //    //browser.IconPath = (string)browserIconPath.GetValue(null);
            //    internetBrowsers.Add(browser);
            //}

            internetBrowsers = InternetBrowser.GetBrowsers(true);
            foreach (InternetBrowser browser in internetBrowsers)
            {
                cboBrowsers.Items.Add(browser.Name);
            }
            //var temp = BrowserInfo.GetPreferableBrowser();
            cboBrowsers.SelectedIndex = 0;
            cboBrowsers.SelectedIndex = cboBrowsers.Items.IndexOf("Internet Explorer");
        }

        private void initializeDefaultSettings()
        {
            //int i = 0;
            //grpDefaultSettings.Visible = false;
            foreach (SiteSettings site in sites)
            {
                cboDefaultSettings.Items.Add(site.Description);
                //var rb = new RadioButton();
                //rb.Text = site.Description;
                //rb.TabIndex = i;
                //rb.Location = new System.Drawing.Point(20, (i * 20) + 20);
                //rb.Width = grpDefaultSettings.Width - rb.Left -1;
                //rb.Checked = (i == 0);
                //rb.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                //grpDefaultSettings.Controls.Add(rb);
                ////grpDefaultSettings.Controls.Add(new RadioButton
                ////{
                ////    Text = site.Description,
                ////    TabIndex = i,
                ////    Location = new System.Drawing.Point(20, 0 * 20),
                ////    Checked = (i == 0),
                ////    CheckedChanged += new EventHandler(RadioButton_CheckedChanged),
                ////});
                //i += 1;
            }
            //RadioButton_CheckedChanged(grpDefaultSettings, null);
            cboDefaultSettings.SelectedIndex = 0;

        }

        //private void RadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (Control control in grpDefaultSettings.Controls)
        //    {
        //        if (control is RadioButton)
        //        {
        //            RadioButton radio = control as RadioButton;
        //            if (radio.Checked)
        //            {
        //                selectSiteSettings(radio.TabIndex);
        //            }
        //        }
        //    }
        //}

        private async void button2_Click(object sender, EventArgs e)
        {
            await refresh();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await callApi();
        }

        private void cboDefaultSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectSiteSettings();
        }

        private void cboEndpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectEndpoint();
        }
    }
}
