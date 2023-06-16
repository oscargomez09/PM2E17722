using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E17722.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageLista : ContentPage
	{
		public PageLista ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            list.ItemsSource = await App.Instancia.GetAll();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}