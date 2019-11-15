using PetFinder.Models;
using PetFinder.Views;
using PetFinder.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetFinder
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ShowPetFinderLogo(this);
            //TestRepoModel();
        }
        private static Authentication auth = new Authentication();

        private static async Task ShowPetFinderLogo(MainPage mainPage)
        {
            auth = await PetRepository.GetAccessTokenAsync();
            //TODO Add image in header
            var image = FileImageSource.FromResource("Petfinder.Assets.Petfinder logo-white.png");
            //NavigationPage.SetTitleIcon(mainPage, image);
        }

        private void btnAnimals_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnimalsPage(auth));
        }

        private void btnOrganizations_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrganizationsPage(auth));
        }

        //public static async Task TestRepoModel()
        //{
            //Authentication auth = await PetRepository.GetAccessTokenAsync();
            //List<Animal> animals = await PetRepository.GetAnimalsAsync(auth);
            //Debug.WriteLine(animals[1]);
            //Animal animal = await PetRepository.GetAnimalByIdAsync(auth, animals[1].Id);
            //Debug.WriteLine(animal);
            //List<Organization> organizations = await PetRepository.GetOrganizationsAsync(auth);
            //Debug.WriteLine(organizations[2].OpeningHours.Saterday);
            //Organization organization = await PetRepository.GetOrganizationByIdAsync(auth, organizations[2].Id);
            //Debug.WriteLine(organization.Name);

            //Appointment appointment = new Appointment();
            //appointment.ContactPerson = "Jelle De Rammelaere";
            //appointment.Email = "jelle.de.rammelaere@student.howest.be";
            //appointment.AppointmentDate = Convert.ToDateTime("06/09/2019", new DateTimeFormatInfo { FullDateTimePattern = "dd-MM-yyyy" });
            //appointment.AnimalName = "Lizzy";
            //appointment.OrganizationName = "New Hanover County Rabbit Rescue of Wilmington";
            //await PetRepository.PostAppointmentAsync(appointment);
            //await PetRepository.PostMailAsync(appointment);
        //}
    }
}
