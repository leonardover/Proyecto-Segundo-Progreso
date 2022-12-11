using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto_2P.Models
{
    internal class Cl_VariosComentarios
    {
        public ObservableCollection<Cl_Comentario> Notes { get; set; } = new ObservableCollection<Cl_Comentario>();

        public Cl_VariosComentarios() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Cl_Comentario> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.comentarios.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Cl_Comentario()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (Cl_Comentario note in notes)
                Notes.Add(note);
        }

     }
}
