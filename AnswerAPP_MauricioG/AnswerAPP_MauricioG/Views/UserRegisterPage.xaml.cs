using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerAPP_MauricioG.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerAPP_MauricioG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {

        UserViewModel viewModel;

        public UserRegisterPage()
        {
            InitializeComponent();


            //Estamos anclando la vista con el viewmodel respectivo
            BindingContext = viewModel = new UserViewModel();

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

        private async void CmdVolver(object sender, EventArgs e)
        {
            await Navigation.PopAsync();       
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            // TODO: Se deben validar datos minimos, estructura del email, complejidad de contraseña

            bool R = await viewModel.AddUser(TxtUserName.Text.Trim(),
                                            TxtFirstName.Text.Trim(),
                                            TxtLastName.Text.Trim(),
                                            TxtPhoneNumber.Text.Trim(),
                                            TxtPassword.Text.Trim(),
                                            TxtBackUpEmail.Text.Trim(),
                                            TxtJobDescription.Text.Trim());

            if (R) {
                await DisplayAlert("Warning", "The user was added successfully", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Warning", "Something went wrong", "OK");
            }



        }
    }
}