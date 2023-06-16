using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.PlatformConfiguration;

namespace PM2E17722
{
    public partial class MainPage : ContentPage
    {

        Plugin.Media.Abstractions.MediaFile photo = null;

        bool resul = false;

        public MainPage()
        {
            InitializeComponent(); 
        }

        public String Getimage64()
        {
            if(photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    String Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }
            return null;
        }

        public byte[] GetimageBytes()
        {
            if(photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }
            }
            return null;
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {

            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "imagen",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var datos = new Models.Datos
            {
                latitud = latitud.Text,
                longitud = longitud.Text,
                descripcion = descripcion.Text,
                foto = GetimageBytes()
            };

            if(await App.Instancia.AddDatos(datos) > 0)
            {
                await DisplayAlert("Aviso", "Datos ingresados con exito", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "A ocurrido un error", "OK");
            }
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageLista());
        }

        private void btnsalir_Clicked(object sender, EventArgs e)
        {

        }









        private async void btnmapa_Clicked(object sender, EventArgs e)
        {
            resul = await DisplayAlert("TERMINOS DE USO", "¿TIENE ENCENDIDO SU GPS?", "SI", "NO");

            if (resul == true)
            {
                await Navigation.PushAsync(new PageMapa());

            }
            else
            {
                await DisplayAlert("ERROR", "SE NECESITA ENCENDER EL GPS PARA GEOLOCALIZACION", "CERRAR");

            }
        }
    }
}
