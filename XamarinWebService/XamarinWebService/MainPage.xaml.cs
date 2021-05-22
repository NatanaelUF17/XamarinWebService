using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWebService.Models;
using XamarinWebService.Repository;
using XamarinWebService.Services;
using XamarinWebService.Views;

namespace XamarinWebService
{
    public partial class MainPage : ContentPage
    {
        PersonRestService _personRestService;

        public MainPage()
        {
            InitializeComponent();
            _personRestService = new PersonRestService();
        }

        async void OnFetchButtonClicked(object sender, EventArgs e)
        {
            PersonRepository.Root personResponse = await _personRestService.GetPersonsAsync(Constants.RandomUserEndPoint);
            List<Person> persons = new List<Person>();

            for (int i = 0; i < personResponse.Results.Count; i++)
            {
                persons.Add(new Person
                {
                    Name = personResponse.Results[i].Name.First,
                    Lastname = personResponse.Results[i].Name.Last,
                    Thumbnail = personResponse.Results[i].Picture.Thumbnail
                });
            }

            collectionView.ItemsSource = persons;
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.CurrentSelection != null)
                {
                    Person person = (Person)e.CurrentSelection.FirstOrDefault();                   
                    await Shell.Current.GoToAsync($"{nameof(PersonDetailPage)}?{nameof(PersonDetailPage.ItemName)}={person.Name}&{nameof(PersonDetailPage.ItemLastname)}={person.Lastname}&{nameof(PersonDetailPage.ItemThumbnail)}={person.Thumbnail}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tErro {ex.Message}");
            }
        }
    }
}
