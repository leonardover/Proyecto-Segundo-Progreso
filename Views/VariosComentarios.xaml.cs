namespace Proyecto_2P.Views;

public partial class VariosComentarios : ContentPage
{
    public VariosComentarios()
    {
        InitializeComponent();

        BindingContext = new Models.Cl_VariosComentarios();
    }

    protected override void OnAppearing()
    {
        ((Models.Cl_VariosComentarios)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Comentario));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Cl_Comentario)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Comentario)}?{nameof(Comentario.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }   
    }
}