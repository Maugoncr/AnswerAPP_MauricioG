using AnswerAPP_MauricioG.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnswerAPP_MauricioG.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}