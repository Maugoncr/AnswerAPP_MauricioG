using AnswerAPP_MauricioG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerAPP_MauricioG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {

                TxtPassword.IsPassword = false;


            }
            else
            {
                TxtPassword.IsPassword = true;
            }

        }

        private async void CmdUserRegister(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new UserRegisterPage());

        }
    }
} 