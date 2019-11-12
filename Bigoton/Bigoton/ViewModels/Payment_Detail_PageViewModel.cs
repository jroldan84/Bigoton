using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bigoton.ViewModels
{
    public class Payment_Detail_PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand payment;

        public Payment_Detail_PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand PaymentCommand => payment ?? (payment = new DelegateCommand(paycalculate));

        public async void paycalculate()
        {
            await _navigationService.NavigateAsync("Barber_List_Page");
        }
    }

}
