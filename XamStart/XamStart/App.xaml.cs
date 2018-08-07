using XamStart.Factories;
using XamStart.Interfaces;
using XamStart.Views;
using System;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamStart.ViewModels;
using XamStart.Helpers;
using System.Runtime.CompilerServices;

#if (DEBUG == false)
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
#endif
namespace XamStart
{
	public partial class App : Application
	{
        public App ()
		{
			InitializeComponent();
            loadLoginPage();
        }

        
        private void loadHTMLErrorPage()
        {
            var page = (Page)ViewModelLocator.Container.Resolve<IErrorPage>();
            MainPage = page;
        }
        private void loadMainPage()
        {
            var page = (Page)ViewModelLocator.Container.Resolve<IMDPage>();            
            MainPage = page;
        }
        private void loadLoginPage()
        {
            var page = (Page)ViewModelLocator.Container.Resolve<ILoginPage>();
            MainPage = page;
        }
        private void StartSubscriptions()
        {
            MessagingCenter.Subscribe<IForSendingMessageToAppStart, string>(this, "MessageSend", (sender, args) =>
            {
                // because a message might have come from a viewmodel, make sure we are back on main thread
                Device.BeginInvokeOnMainThread(() => {
                    switch (args)
                    {
                        case "Home":
                        case "Authenticated":
                            loadMainPage();
                            break;
                        case "HTML Error":
                            loadHTMLErrorPage();
                            break;
                        case "Logout":
                            loadLoginPage();
                            break;
                        default:
                            break;
                    }
                });                
            });

        }
       
        protected override void OnStart ()
		{
            StartSubscriptions();
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{

			// Handle when your app resumes
		}
	}
}
