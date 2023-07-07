using System.Collections.ObjectModel;
namespace Notas.Models;
internal class TodasNotas
{
    public ObservableCollection<Nota> Notas { get; set; } = new ObservableCollection<Nota>
   ();
    public TodasNotas() =>
    CarregaNotas();
    public void CarregaNotas()
    {
        Notas.Clear();
        // Obtem a diretoria onde as notas são armazenadas.
        string appDataPath = FileSystem.AppDataDirectory;
        // usa as extensões Linq para carregar os ficheiros *.notas.txt
        IEnumerable<Nota> notas = Directory
       // Seleciona os nomes de ficheiros da diretoria
       .EnumerateFiles(appDataPath, "*.notas.txt")
       // Cada ficheiro é utilizado para criar uma nova nota
       .Select(filename => new Nota()
       {
           Filename = filename,
           Text = File.ReadAllText(filename),
           Date = File.GetCreationTime(filename)
       })
       // Com a coleção final de notas, ordena por data
       .OrderBy(nota => nota.Date);
        // Adiciona cada nota na ObservableCollection
        foreach (Nota nota in notas)
            Notas.Add(nota);
    }
}