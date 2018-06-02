using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using XamStart.Interfaces;
using XamStart.Models;
using Xamarin.Forms;
using Unity;

namespace XamStart.ViewModels
{
    public class LoginPageViewModel : BaseViewModel, ILoginPageViewModel, IForSendingMessageToAppStart
    {
        ILoginService loginService;
        
        public LoginPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, ILoginService loginService) : base(currentlySelectedFactory)
        {
            this.loginService = loginService;
        }



        protected override async Task Init()
        {
            IsBusy = true;
            var wasLoginGood = await loginService.Login();
            IsBusy = false;
            if (wasLoginGood)
            {
                HandleGoodResult();
            }
            else
            {
                HandleBadResult();
            }
        }


        private void HandleGoodResult() => MessagingCenter.Send<IForSendingMessageToAppStart, string>(this, "MessageSend", "Authenticated");

        private void HandleBadResult()
        {
            var user = currentlySelectedFactory.SelectedUser;
            if (user.Error.isHTML)
            {
                RaiseHTMLError();
            }
            else
            {
                SendErrorToView(user.Error.issue);
            }
            
        }

        private void RaiseHTMLError() => MessagingCenter.Send<IForSendingMessageToAppStart, string>(this, "MessageSend", "HTML Error");

        private void SendErrorToView(string issue) => MessagingCenter.Send<ILoginPageViewModel, Tuple<string, string>>(this, "MessageSend", new Tuple<string, string>("Authentication Failed", issue));

    }
}
