using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamStart.Interfaces;

namespace XamStart.ViewModels
{
    public class LogoutPageViewModel : BaseViewModel, ILogoutPageViewModel, IForSendingMessageToAppStart
    {
        IPlatformLogout platformLogout;
        public LogoutPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, IPlatformLogout platformLogout) : base(currentlySelectedFactory)
        {
            this.platformLogout = platformLogout;
            LogoutCommand = new Command(Logout);
            CancelCommand = new Command(Cancel);
        }

        public ICommand LogoutCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        private void Cancel()
        {
            MessagingCenter.Send<IForSendingMessageToAppStart, string>(this, "MessageSend", "Home");
        }
        private void Logout()
        {
            platformLogout.Logout();
            MessagingCenter.Send<IForSendingMessageToAppStart, string>(this, "MessageSend", "Logout");
        }
    }
}
