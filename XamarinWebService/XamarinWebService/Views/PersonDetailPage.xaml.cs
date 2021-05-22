using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWebService.Models;
using XamarinWebService.Repository;
using XamarinWebService.Services;

namespace XamarinWebService.Views
{
    [QueryProperty(nameof(ItemName), nameof(ItemName))]
    [QueryProperty(nameof(ItemLastname), nameof(ItemLastname))]
    [QueryProperty(nameof(ItemThumbnail), nameof(ItemThumbnail))]
    public partial class PersonDetailPage : ContentPage
    {
        public PersonDetailPage()
        {
            InitializeComponent();
        }

        string _name;
        string _lastName;
        string _thumbnail;

        public string ItemName
        {
            set
            {
                _name = Uri.UnescapeDataString(value);
                name.Text = _name;
            }
        }

        public string ItemLastname
        {
            set
            {
                _lastName = Uri.UnescapeDataString(value);
                lastName.Text = _lastName;
            }
        }

        public string ItemThumbnail
        {
            set
            {
                _thumbnail = Uri.UnescapeDataString(value);
                thumbnail.Source = _thumbnail;
            }
        }
    }
}