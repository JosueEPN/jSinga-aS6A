using jSingañaS6A.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jSingañaS6A.Views;

public partial class estudiantes : ContentPage
{
    private const string Url = "http://192.168.100.41/movilesUisrael/estudiante.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estud;
    public estudiantes()
	{
		InitializeComponent();
        Obtener();

    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estud = new ObservableCollection<Estudiante>(mostrarEst);
        listaEstudiantes.ItemsSource = estud;
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vInsertar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActEli(objEstudiante));
    }
}