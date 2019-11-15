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
    public partial class AnimalsPage : ContentPage
    {
        public List<Animal> animals;
        public AnimalsPage(Authentication auth)
        {
            animals = new List<Animal>();
            InitializeComponent();
            ShowAnimals(auth);
        }
            
        private async Task ShowAnimals(Authentication auth)
        {
            //TODO Add image in header

            animals = await PetRepository.GetAnimalsAsync(auth);
            
            animals = await CreateFirstImageAsync(animals);
            lvwAnimals.ItemsSource = animals;

        }
        /// <summary>
        /// Gets the first image of an animal his photolist 
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        private async Task<List<Animal>> CreateFirstImageAsync(List<Animal> animals)
        {
            //TODO System.ObjectDisposedException: 'Can not access a closed Stream.'
            List<Animal> listofAnimals = new List<Animal>();
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < animals.Count - 1; i++)
                {
                    try
                    {
                        Animal animalTemp = animals[i];
                        string url;

                        if (animalTemp.AnimalPhotoList != null && animalTemp.AnimalPhotoList.Count != 0)
                        {
                            url = animalTemp.AnimalPhotoList[0].MediumPhoto;
                        }
                        else
                        {
                            if (animalTemp.Species.ToLower() == "dog")
                                url = @"https://www.wikihow.com/images/6/64/Stop-a-Dog-from-Jumping-Step-6-Version-2.jpg";
                            else if (animalTemp.Species.ToLower() == "cat")
                                url = @"https://ihavecat.com/wp-content/uploads/2014/01/cat-asking-for-help-option-2.jpg";
                            else 
                                url = @"https://www.pets4homes.co.uk/images/articles/645/large/1f35195ae1aa637531e546b3ff5c9439.jpg";
                            //switch (animalTemp.Species.ToLower())
                            //{
                            //    case "dog":
                            //        url = @"https://www.wikihow.com/images/6/64/Stop-a-Dog-from-Jumping-Step-6-Version-2.jpg";
                            //        break;
                            //    case "cat":
                            //        url = @"https://ihavecat.com/wp-content/uploads/2014/01/cat-asking-for-help-option-2.jpg";
                            //        break;
                            //    default:
                            //        url = @"https://www.pets4homes.co.uk/images/articles/645/large/1f35195ae1aa637531e546b3ff5c9439.jpg";
                            //        break;
                            //}
                        }
                        using (Stream stream = await client.GetStreamAsync(url))
                        {
                            animalTemp.FirstImage = ImageSource.FromStream(() => stream);
                            //test.Source = ImageSource.FromStream(() => stream);


                        }
                        listofAnimals.Add(animalTemp);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + "\n\r" + ex.StackTrace);
                    }
                }
            }
            return listofAnimals;
        }
        private void lvwAnimals_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Animal selectedAnimal = lvwAnimals.SelectedItem as Animal;
            if (selectedAnimal != null)
                Navigation.PushAsync(new AnimalPage(selectedAnimal));
            selectedAnimal = null;
        }
    }
}