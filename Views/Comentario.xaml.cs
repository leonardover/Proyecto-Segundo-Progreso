namespace Proyecto_2P.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class Comentario : ContentPage
{
    //string _fileName = Path.Combine(FileSystem.AppDataDirectory, "comentarios.txt");
    public Comentario()
	{
		InitializeComponent();
        
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.comentarios.txt";

        CargarComentario(Path.Combine(appDataPath, randomFileName));
        //CargarComentario(_fileName);
    }

    private async void Bguardar_Clicked(object sender, EventArgs e)
    {
        //Guarda el Archivo
        if (BindingContext is Models.Cl_Comentario note)
            File.WriteAllText(note.Filename, Editor.Text);

        await Shell.Current.GoToAsync("..");    
    }

    private async void Beliminar_Clicked(object sender, EventArgs e)
    {
        // Eliminar este Archivo
        if (BindingContext is Models.Cl_Comentario note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void CargarComentario(string fileName)
    {
        Models.Cl_Comentario noteModel = new Models.Cl_Comentario();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { CargarComentario(value); }
    }


}