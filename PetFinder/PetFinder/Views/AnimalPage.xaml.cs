using PetFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalPage : ContentPage
    {
        Animal selectedAnimal = new Animal();
        public AnimalPage(Animal animal)
        {
            selectedAnimal = animal;
            InitializeComponent();
            ShowAnimal(animal);
        }

        private void ShowAnimal(Animal animal)
        {
            lblName.Text = animal.Name;
            lblSpecies.Text = animal.Species;
            lblAge.Text = animal.Age;
            lblGender.Text = animal.Gender;
            lblSize.Text = animal.Size;
            lblDescription.Text = animal.Description;
            lblStatus.Text = animal.Status;
            //TODO Add Images
        }

        private void btnAppointment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AppointmentPage(selectedAnimal));
        }
    }
}