using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkToolkit.Services
{
    public interface IUEFISettingsService
    {
        public bool GetFlipToBootStatus();
        public int SetFlipToBootStatus(bool newStatus);
    }
}
