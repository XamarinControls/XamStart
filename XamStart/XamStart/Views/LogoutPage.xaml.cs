using XamStart.Interfaces;

using Xamarin.Forms;

namespace XamStart.Views
{
    public partial class LogoutPage : ContentPageBase, ILogoutPage
    {
        public LogoutPage()
        {
            InitializeComponent();           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Track("LogoutPage Page");
        }
    }
}