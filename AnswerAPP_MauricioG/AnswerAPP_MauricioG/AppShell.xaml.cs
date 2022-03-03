using AnswerAPP_MauricioG.ViewModels;
using AnswerAPP_MauricioG.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AnswerAPP_MauricioG
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
