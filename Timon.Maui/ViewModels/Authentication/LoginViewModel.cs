using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timon.Maui.ViewModels.Authentication
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
#if DEBUG

#endif
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
};
