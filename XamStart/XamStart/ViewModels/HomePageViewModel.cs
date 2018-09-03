using XamStart.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamStart.ViewModels
{
    public class HomePageViewModel : BaseViewModel, IHomePageViewModel
    {
        IToastService toastService;
        INavigationService navigationService;

        string navigationTrick;
        public string NavigationTrick
        {
            get { return navigationTrick; }
            set { SetProperty(ref navigationTrick, value); }
        }

        public HomePageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, IToastService toastService, INavigationService navigationService) : base(currentlySelectedFactory)
        {
            Title = "My Home!!!";
            this.toastService = toastService;
            this.navigationService = navigationService;
            ShowToastCommand = new Command(() => this.toastService.CookIt("Something Important", Models.MyToastLength.Long));
            SubPageCommand = new Command(async() => await NavigateToChild());
            MDNavCommand = new Command(() => MDDetailPageNavigate());
        }
        private async Task NavigateToChild()
        {
            await navigationService.NavigateToChildPage(typeof(IHelpPage));
        }
        private void MDDetailPageNavigate(){
            navigationService.MDDetailPageNavigate(typeof(ISettingsPage));
        }
        public ICommand ShowToastCommand { get; set; }
        public ICommand MDNavCommand { get; set; }
        public ICommand SubPageCommand { get; set; }
    }    
}
