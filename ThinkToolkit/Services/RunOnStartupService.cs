using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkToolkit.Services
{
    public class RunOnStartupService : IRunOnStartupService
    {
        private static string _assemblyPath
        {
            get
            {
                return Environment.ProcessPath;
            }
        }
        public bool IsRunOnStartupEnabled()
        {
            bool result;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run"))
            {
                bool flag = key == null;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    object o = key.GetValue("ThinkToolkit");
                    result = (o != null);
                }
            }
            return result;
        }

        public void ToggleRunOnStartup()
        {
            if (!this.IsRunOnStartupEnabled())
            {
                EnableRunAtStartup();
            }
            else
            {
                DisableRunAtStartup();
            }
        }

        private static void DisableRunAtStartup()
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            bool flag = key != null;
            if (flag)
            {
                try
                {
                    key.DeleteValue("ThinkToolkit");
                }
                catch (ArgumentException)
                {
                }
            }
        }

        private static void EnableRunAtStartup()
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("ThinkToolkit", _assemblyPath + " nogui");
        }
    }
}
