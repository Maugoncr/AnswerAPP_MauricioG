using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AnswerAPP_MauricioG.ViewModels;

namespace AnswerAPP_MauricioG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyQuestionsPage : ContentPage
    {

        AskViewModel askViewModel;
        public MyQuestionsPage()
        {
            InitializeComponent();

            BindingContext = askViewModel = new AskViewModel();

            // TODO: Hasta no tener el usuario global vamos a tener que quemar el ID del usuario

            askViewModel.MyQuestion.UserId = 2005;

            LoadList();

        }

        private async void LoadList() { 
        
            LstMyQuestions.ItemsSource = await askViewModel.GetQList(); 
        
        }

    }
}