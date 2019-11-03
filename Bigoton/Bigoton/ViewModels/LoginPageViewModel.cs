using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Bigoton.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private DelegateCommand _logincommand;
        private readonly INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Email = "jroldan84@hotmail.com.co";
            Password = "123456";
        }

        public string  Email { get; set; }
        public string Password { get; set; }
        public DelegateCommand LoginCommand => _logincommand ?? (_logincommand = new DelegateCommand(Login));

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "you must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "you must enter an Password", "Accept");
                return;
            }

            if (Email.Equals("jroldan84@hotmail.com.co") || Password.Equals("123456"))
            {
                await App.Current.MainPage.DisplayAlert("Hello" ,"", "Accept");
                await _navigationService.NavigateAsync("Barber_List_Page");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "bad login", "Accept");
                return;
            }



        }

    }
}
