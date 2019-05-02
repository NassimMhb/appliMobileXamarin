using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Appli12.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appli12
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPagexaml : ContentPage
	{
		public NoteEntryPagexaml ()
		{
			InitializeComponent ();
		}
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Commercants)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update
                File.WriteAllText(note.Filename, note.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Commercants)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}