using PetFinder.Models;
using PetFinder.Repositories;
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
    public partial class AppointmentPage : ContentPage
    {
        
        public AppointmentPage(Animal animal)
        {
            InitializeComponent();
            selectedAnimal = animal;
            GetDateTimeDatePicker();
        }

        private Animal selectedAnimal = new Animal();

        private void GetDateTimeDatePicker()
        {
            datePicker.Date = DateTime.UtcNow;
            datePicker.MinimumDate = DateTime.Now + TimeSpan.FromHours(24);
            datePicker.MaximumDate = DateTime.Now.AddMonths(3);
        }
        /// <summary>
        /// Creates a new appointment out of the filled in text. 
        /// Add the appointment to Azure Table Storage and mail the ContactPerson.
        /// </summary>
        /// <returns></returns>
        private async Task CreateAppointmentAsync()
        {
            Authentication auth = await PetRepository.GetAccessTokenAsync();
            Appointment appointment = new Appointment();
            Organization organization = await PetRepository.GetOrganizationByIdAsync(auth, selectedAnimal.OrganizationId);
            appointment.OrganizationName = organization.Name;
            appointment.AnimalName = selectedAnimal.Name;
            //TODO Check if these checks work!
            if (editContactPerson.Text.Length > 3)
                appointment.ContactPerson = editContactPerson.Text;
            //else
                //TODO return message if it's invalid
            bool checkEmail = IsValidEmail(editEmail.Text);
            if (checkEmail == true)
                appointment.Email = editEmail.Text;
            //else
                //TODO return message if it's invalid
            appointment.AppointmentDate = datePicker.Date;
            await PetRepository.PostAppointmentAsync(appointment);
            await PetRepository.PostMailAsync(appointment);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Pressed(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        
        private void btnCreateAppointment_Pressed(object sender, EventArgs e)
        {
            //TODO message if appointment was succesful
            CreateAppointmentAsync();
            Navigation.PopAsync();
        }

    }
}