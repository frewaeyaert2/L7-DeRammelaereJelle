using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace PetFinder.Models
{
    public class Animal
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty(PropertyName = "species")]
        public string Species { get; set; }
        [JsonProperty(PropertyName = "age")]
        public string Age { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "photos")]
        private List<Photos> animalPhotoList;
        public List<Photos> AnimalPhotoList
        {
            get { return animalPhotoList; }
            set 
            { 
                if (value.Count != 0)
                    animalPhotoList = value;
            }
        }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        public class Photos
        {
            [JsonProperty(PropertyName = "small")]
            public string SmallPhoto { get; set; }
            [JsonProperty(PropertyName = "medium")]
            public string MediumPhoto { get; set; }
            [JsonProperty(PropertyName = "large")]
            public string LargePhoto { get; set; }
            [JsonProperty(PropertyName = "full")]
            public string FullPhoto { get; set; }
        }
        public ImageSource FirstImage { get; set; }
    }
}
