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
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel Vm;


        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new UserViewModel();
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

            await Navigation.PushAsync(new UserRegisterPageV2());
            //UserRegisterPage la antigua V2 con commandas

        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            bool R = await Vm.ValidateUserAccess(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());

            if (R) {

                //TODO quitar este mensaje porque es un bostezo
                await DisplayAlert(":)", "Correct User", "OK");

                await Navigation.PushAsync(new ActionsPage());

            }
            else
            {
                await DisplayAlert(":(", "Incorrect User or Password!", "OK");
                TxtPassword.Focus();
               
            }
        }





    }
} 