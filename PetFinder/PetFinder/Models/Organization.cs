using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PetFinder.Models
{
    public class Organization
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "address")]
        public AdressInformation Adress { get; set; }
        [JsonProperty(PropertyName = "hours")]
        public Hours OpeningHours { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string WesiteURL { get; set; }
        [JsonProperty(PropertyName = "photos")]
        private List<Photos> photos;
        public List<Photos> OrganizationPhotoList
        {
            get { return photos; }
            set 
            { 
                if (value.Count != 0)
                    photos = value; 
            }
        }
        public class AdressInformation
        {
            [JsonProperty(PropertyName = "address1")]
            public string Address { get; set; }
            [JsonProperty(PropertyName = "address2")]
            public string Address2 { get; set; }
            [JsonProperty(PropertyName = "city")]
            public string City { get; set; }
            [JsonProperty(PropertyName = "state")]
            public string State { get; set; }
            [JsonProperty(PropertyName = "postcode")]
            public string PostalCode { get; set; }
            [JsonProperty(PropertyName = "country")]
            public string Country { get; set; }
        }
        public class Hours
        {
            [JsonProperty(PropertyName = "monday")]
            public string Monday { get; set; }
            [JsonProperty(PropertyName = "tuesday")]
            public string Tuesday { get; set; }
            [JsonProperty(PropertyName = "wednesday")]
            public string Wednesday { get; set; }
            [JsonProperty(PropertyName = "thursday")]
            public string Thursday { get; set; }
            [JsonProperty(PropertyName = "friday")]
            public string Friday { get; set; }
            [JsonProperty(PropertyName = "saterday")]
            public string Sunday { get; set; }
            [JsonProperty(PropertyName = "sunday")]
            public string Saterday { get; set; }
        }
        public class Photos
        {
            [JsonProperty(PropertyName = "small")]
            public String SmallPhoto { get; set; }
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
