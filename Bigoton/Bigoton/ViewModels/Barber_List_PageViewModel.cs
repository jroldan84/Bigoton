using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;



namespace Bigoton.ViewModels
{
    public class Barber_List_PageViewModel : ViewModelBase
    {

        private DelegateCommand _Barber_Details_command;
        private readonly INavigationService _navigationService;

        public Barber_List_PageViewModel(INavigationService navigationService) : base(navigationService)
        {

            _navigationService = navigationService;

        }
      public DelegateCommand Details_Barber_Command => _Barber_Details_command ?? (_Barber_Details_command = new DelegateCommand(Details));

        private async void Details()
        {
            await _navigationService.NavigateAsync("Barber_Detail_Page");
        }
    }
}
