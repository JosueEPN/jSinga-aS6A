using jSingañaS6A.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jSingañaS6A.Views;

public partial class estudiantes : ContentPage
{
    private const string Url = "http://10.2.1.113/movilesUisrael/estudiante.php";
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
}