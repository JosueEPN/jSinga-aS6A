using System.Net;

namespace jSingañaS6A.Views;

public partial class vInsertar : ContentPage
{
	public vInsertar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.100.41/movilesUisrael/estudiante.php", "POST", parametros);
			Navigation.PushAsync(new estudiantes());
        }
		catch (Exception ex)
		{
			DisplayAlert("ERROR", ex.Message, "Cerrar");
			throw;
		}
    }
}