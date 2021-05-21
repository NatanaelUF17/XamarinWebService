using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWebService.Models;
using XamarinWebService.Repository;
using XamarinWebService.Services;

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
    }
}
