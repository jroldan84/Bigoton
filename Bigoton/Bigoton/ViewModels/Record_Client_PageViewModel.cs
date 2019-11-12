using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bigoton.ViewModels
{
    public class Record_Client_PageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand payment;

        public Record_Client_PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand PaymentCommand => payment ?? (payment = new DelegateCommand(Calculate));

        public async void Calculate()
        {
            //codigo para cargar los datos
        }
    }

}
