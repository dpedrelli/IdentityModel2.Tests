// http://stackoverflow.com/questions/2370732/how-to-find-all-the-browsers-installed-on-a-machine
// http://www.rhizohm.net/irhetoric/post/2009/04/03/0a-Finding-All-Installed-Browsers-in-Windows-XP-and-Vista-ndash3b-beware-64bit!0a-.aspx
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace WinFormsClient.Helpers
{
    public class InternetBrowser
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconPath { get; set; }

        public static List<InternetBrowser> GetBrowsers(bool includeDefault)
        {
            List<InternetBrowser> internetBrowsers = new List<InternetBrowser>();

            if (includeDefault)
            {
                internetBrowsers.Add(new InternetBrowser { Name = "Default", Path = "", IconPath = "" });
            }

            // https://msdn.microsoft.com/en-us/library/system.environment.osversion(v=vs.110).aspx
            if (Environment.OSVersion.Version.Major > 5)
            {
                // http://stackoverflow.com/questions/31164253/how-to-open-url-in-microsoft-edge-from-the-command-line
                internetBrowsers.Add(new InternetBrowser { Name = "Edge", Path = @"microsoft-edge:", IconPath = "" });
            }

            RegistryKey browserKeys;
            //on 64bit the browsers are in a different location
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

            string[] browserNames = browserKeys.GetSubKeyNames();

            for (int i = 0; i < browserNames.Length; i++)
            {
                InternetBrowser browser = new InternetBrowser();
                RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
                browser.Name = (string)browserKey.GetValue(null);
                RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
                browser.Path = (string)browserKeyPath.GetValue(null);
                RegistryKey browserIconPath = browserKey.OpenSubKey(@"DefaultIcon");
                browser.IconPath = (string)browserIconPath.GetValue(null);
                internetBrowsers.Add(browser);
            }

            return internetBrowsers;
        }
    }
}
