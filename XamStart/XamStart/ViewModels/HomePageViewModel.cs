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
        public HomePageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, IToastService toastService) : base(currentlySelectedFactory)
        {
            Title = "My Home!!!";
            this.toastService = toastService;
            ShowToastCommand = new Command(() => this.toastService.CookIt("Something Important", Models.MyToastLength.Long));
        }

        public ICommand ShowToastCommand { get; set; }
    }    
}
