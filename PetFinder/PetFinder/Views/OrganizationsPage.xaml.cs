using PetFinder.Models;
using PetFinder.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganizationsPage : ContentPage
    {
        public OrganizationsPage(Authentication auth)
        {
            InitializeComponent();
            ShowOrganizations(auth);
        }

        private async Task ShowOrganizations(Authentication auth)
        {
            //TODO Add image in header

            List<Organization> organizations = await PetRepository.GetOrganizationsAsync(auth);
            await CreateFirstImageAsync(organizations);
            lvwOrganizations.ItemsSource = organizations;

            //TODO get the image of an Organization and at it to the imagesrc of the Organization
        }
        /// <summary>
        /// Gets the first image of an animal his photolist 
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        private async Task CreateFirstImageAsync(List<Organization> organizations)
        {
            //TODO System.ObjectDisposedException: 'Can not access a closed Stream.'
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < organizations.Count - 1; i++)
                {
                    try
                    {
                        Organization organization = organizations[i];
                        string url;

                        if (organization.OrganizationPhotoList != null && organization.OrganizationPhotoList.Count != 0)
                        {
                            url = organization.OrganizationPhotoList[0].MediumPhoto;
                        }
                        else
                        {
                            url = @"https://www.aspca.org/sites/default/files/aspca.jpg";
                        }
                        using (Stream stream = await client.GetStreamAsync(url))
                        {
                            organization.FirstImage = ImageSource.FromStream(() => stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + "\n\r" + ex.StackTrace);
                    }
                }
            }
        }
        private void lvwOrganizations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Organization organization = lvwOrganizations.SelectedItem as Organization;
            if (organization != null)
                Navigation.PushAsync(new OrganizationPage(organization));
            organization = null;
        }
    }
}