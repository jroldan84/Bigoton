using Prism;
using Prism.Ioc;
using Bigoton.ViewModels;
using Bigoton.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Bigoton
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<Barber_List_Page, Barber_List_PageViewModel>();
            containerRegistry.RegisterForNavigation<Barber_Detail_Page, Barber_Detail_PageViewModel>();
            containerRegistry.RegisterForNavigation<Payment_Detail_Page, Payment_Detail_PageViewModel>();
            containerRegistry.RegisterForNavigation<Meeting_Client_Page, Meeting_Client_PageViewModel>();
            containerRegistry.RegisterForNavigation<Register_Page, Register_PageViewModel>();
            containerRegistry.RegisterForNavigation<Record_Client_Page, Record_Client_PageViewModel>();
            containerRegistry.RegisterForNavigation<Edit_Profile_Page, Edit_Profile_PageViewModel>();
        }
    }
}
