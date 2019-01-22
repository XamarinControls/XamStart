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
using FFImageLoading.Svg.Forms;

#if (DEBUG == false)
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
#endif
namespace XamStart
{
	public partial class App : Application
	{
        //public static Page Page;
        public App ()
		{
			InitializeComponent();
            // DO NOT DELETE THIS NEXT LINE!  See https://github.com/luberda-molinet/FFImageLoading/issues/663
            var x = new SvgImageSourceConverter();
            var navigateService = ViewModelLocator.Container.Resolve<INavigationService>();
            navigateService.RootNavigate(typeof(ILoginPage));
        }
       
        protected override void OnStart ()
		{
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
