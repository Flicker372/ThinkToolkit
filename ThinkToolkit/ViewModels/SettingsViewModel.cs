using CommunityToolkit.Mvvm.ComponentModel;
using ThinkToolkit.Services;
using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkToolkit.ViewModels
{

    [INotifyPropertyChanged]
    public partial class SettingsViewModel
    {
        private readonly IRunOnStartupService _runOnStartupService;

        public SettingsViewModel(IRunOnStartupService runOnStartupService)
        {
            _runOnStartupService = runOnStartupService;
        }

        public bool IsRunOnStartupEnabled
        {
            get
            {
                return _runOnStartupService.IsRunOnStartupEnabled();
            }
            set
            {
                try
                {
                    _runOnStartupService.ToggleRunOnStartup();
                }
                catch (Exception ex)
                {
                    var dialog = new ContentDialog
                    {
                        Title = "错误",
                        Content = ex.Message,
                        CloseButtonText = "确定"
                    }.ShowAsync();
                    
                }
            }
        }
    }
}
