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
    public partial class OrganizationPage : ContentPage
    {
        public OrganizationPage(Organization organization)
        {
            InitializeComponent();
            ShowOrganization(organization);
        }

        private void ShowOrganization(Organization organization)
        {
            lblName.Text = organization.Name;
            lblAddress.Text = organization.Adress.Address + organization.Adress.Address2;
            lblPhone.Text = organization.Phone;
            lblEmail.Text = organization.Email;
            //TODO Check the current day and print the OpeningHours for this day => System.reflection => property at runtime op te halen (bv. Zoals we de csv ophalen,)
            string day = System.DateTime.Now.DayOfWeek.ToString();
            switch (day)
            {
                case "Monday":
                    lblOpeningHours.Text = organization.OpeningHours.Monday;
                    break;
                case "Tuesday":
                    lblOpeningHours.Text = organization.OpeningHours.Tuesday;
                    break;
                case "Wednesday":
                    lblOpeningHours.Text = organization.OpeningHours.Wednesday;
                    break;
                case "Thursday":
                    lblOpeningHours.Text = organization.OpeningHours.Thursday;
                    break;
                case "Friday":
                    lblOpeningHours.Text = organization.OpeningHours.Friday;
                    break;
                case "Saturday":
                    lblOpeningHours.Text = organization.OpeningHours.Saterday;
                    break;
                case "Sunday":
                    lblOpeningHours.Text = organization.OpeningHours.Sunday;
                    break;
                default:
                    lblOpeningHours.Text = "No openinghours found for this organization.";
                    break;
            }
            lblURL.Text = organization.WesiteURL;
            //TODO Add Images
        }

        private void btnReturn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}