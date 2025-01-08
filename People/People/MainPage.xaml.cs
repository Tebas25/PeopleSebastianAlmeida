using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    public async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = await App.PersonRepo.GetAllPeople();
        salmeida_ListaPersonas.ItemsSource = people;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Person personaEliminar)
        {
            await App.PersonRepo.DeletePerson(personaEliminar);
            List<Person> personas = await App.PersonRepo.GetAllPeople();
            salmeida_ListaPersonas.ItemsSource = personas;
            await DisplayAlert("Confirmación", "Sebastian Almeida acaba de eliminar un registro", "OK");
        }
        
    }
}

