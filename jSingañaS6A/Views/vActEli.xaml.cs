using jSingañaS6A.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace jSingañaS6A.Views;

public partial class vActEli : ContentPage
{
    
	public vActEli(Estudiante datos)
	{
		InitializeComponent();

        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            /*
             * METODO 1 de Actualizacion
            string url = $"http://192.168.100.41/uisraelws/estudiante.php?id={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";

            // Enviar la solicitud PUT
            cliente.UploadString(url, "PUT", ""); // Enviar una solicitud vacía porque los datos van en la URL
            */
            // Preparamos los parámetros de actualización
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            // Enviamos la solicitud PUT al servidor
            cliente.UploadString($"http://192.168.100.41/uisraelws/estudiante.php?id={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}", "PUT", "");
            Navigation.PushAsync(new estudiantes());
            DisplayAlert("Actualizado", "El estudiante ha sido actualizado correctamente", "Cerrar");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
            throw;
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            string url = $"http://192.168.100.41/movilesUisrael/estudiante.php?codigo={txtCodigo.Text}";

            cliente.UploadValues(url, "DELETE", new System.Collections.Specialized.NameValueCollection());
            DisplayAlert("Eliminado", "El estudiante ha sido eliminado correctamente", "Cerrar");

            // Navega de regreso a la página de estudiantes para ver la lista actualizada
            Navigation.PushAsync(new estudiantes());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
            throw;
        }

    }
}