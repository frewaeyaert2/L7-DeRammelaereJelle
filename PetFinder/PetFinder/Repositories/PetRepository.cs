using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetFinder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Repositories
{
    public static class PetRepository
    {
        /// <summary>
        /// Creates a HttpClient for an call to the API
        /// </summary>
        /// <returns>The created HttpClient </returns>
        private static HttpClient GetHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            //JSON always returns a header and body, ALWAYS add this line!
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }

        /// <summary>
        /// This method request a AccesToken to use for the authentication during the API Calls
        /// It sends JSON with the Token information and receives JSON with the actual authentication key
        /// </summary>
        /// <returns></returns>
        public static async Task<Authentication> GetAccessTokenAsync()
        {            
            string url = "https://api.petfinder.com/v2/oauth2/token?";
            Token token = new Token();
            Authentication auth = new Authentication();

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(token);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Get the authentication info from {json} was unsuccesfull to url: {url}";
                        throw new Exception(errorMsg);
                    }
                    else
                    {
                        string returnedJson = await response.Content.ReadAsStringAsync();
                        auth = JsonConvert.DeserializeObject<Authentication>(returnedJson);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Error in GetAccessTokenAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
            return auth;
        }

        /// <summary>
        /// Gets is List of all animals of the API
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>List of animals</returns>
        public static async Task<List<Animal>> GetAnimalsAsync(Authentication auth)
        {
            List<Animal> animals = new List<Animal>();
            string url = $"https://api.petfinder.com/v2/animals";
            
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //Add the Autohorization Key and value to the http get request header
                    client.DefaultRequestHeaders.Add("Authorization", $"{auth.TokenType} {auth.AccessToken}");
                    //Create string that contains al the json data, from the url we defined
                    string json = await client.GetStringAsync(url);
                    //Put the JSON data into a JSON Object
                    JObject parsedObject = JObject.Parse(json);
                    //Takes the Parsed JSON without the nested sub elemenet an parse it back to a string with json data
                    var animalsJSON = parsedObject["animals"].ToString();
                    //Converts the JSON object to a list of Animals
                    animals = JsonConvert.DeserializeObject<List<Animal>>(animalsJSON);
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Error in GetAnimalsAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
            return animals;
        }

        /// <summary>
        /// Get a animal selected by Id
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="AnimalId"></param>
        /// <returns>Single animal object</returns>
        public static async Task<Animal> GetAnimalByIdAsync(Authentication auth, int AnimalId)
        {
            Animal animal = new Animal();
            string url = $"https://api.petfinder.com/v2/animals/{AnimalId}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //Add the Autohorization Key and value to the http get request header
                    client.DefaultRequestHeaders.Add("Authorization", $"{auth.TokenType} {auth.AccessToken}");
                    //Create string that contains al the json data, from the url we defined
                    string json = await client.GetStringAsync(url);
                    //Put the JSON data into a JSON Object
                    JObject parsedObject = JObject.Parse(json);
                    //Takes the Parsed JSON without the nested sub elemenet an parse it back to a string with json data
                    var animalJSON = parsedObject["animal"].ToString();
                    //Converts the JSON object to a list of Animals
                    animal = JsonConvert.DeserializeObject<Animal>(animalJSON);
                }
                catch (Exception ex)
                {

                    string errorMsg = $"Error in GetAnimalsByIdAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
            return animal;
        }

        /// <summary>
        /// Gets a list of Organizations where Animals can be adopted
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>List of organizations</returns>
        public static async Task<List<Organization>> GetOrganizationsAsync(Authentication auth)
        {
            List<Organization> organizations = new List<Organization>();
            string url = $"https://api.petfinder.com/v2/organizations";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //Add the Autohorization Key and value to the http get request header
                    client.DefaultRequestHeaders.Add("Authorization", $"{auth.TokenType} {auth.AccessToken}");
                    //Create string that contains al the json data, from the url we defined
                    string json = await client.GetStringAsync(url);
                    //Put the JSON data into a JSON Object
                    JObject parsedObject = JObject.Parse(json);
                    //Takes the Parsed JSON without the nested sub elemenet an parse it back to a string with json data
                    var organisationsJSON = parsedObject["organizations"].ToString();
                    //Converts the JSON object to a list of Animals
                    organizations = JsonConvert.DeserializeObject<List<Organization>>(organisationsJSON);
                }
                catch (Exception ex)
                {

                    string errorMsg = $"Error in GetOrganizationsAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
            return organizations;
        }

        /// <summary>
        /// Gets a Organization by an Id
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="OrganizationId"></param>
        /// <returns>A single organization object</returns>
        public static async Task<Organization> GetOrganizationByIdAsync(Authentication auth, string OrganizationId)
        {
            Organization organization = new Organization();
            string url = $"https://api.petfinder.com/v2/organizations/{OrganizationId}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //Add the Autohorization Key and value to the http get request header
                    client.DefaultRequestHeaders.Add("Authorization", $"{auth.TokenType} {auth.AccessToken}");
                    //Create string that contains al the json data, from the url we defined
                    string json = await client.GetStringAsync(url);
                    //Put the JSON data into a JSON Object
                    JObject parsedObject = JObject.Parse(json);
                    //Takes the Parsed JSON without the nested sub elemenet an parse it back to a string with json data
                    var organisationJSON = parsedObject["organization"].ToString();
                    //Converts the JSON object to a list of Animals
                    organization = JsonConvert.DeserializeObject<Organization>(organisationJSON);
                }
                catch (Exception ex)
                {

                    string errorMsg = $"Error in GetOrganizationsByIdAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
            return organization;
        }       
        /// <summary>
        /// Makes an appointment if a user want to meet the Animal in the organization where they wan to adopt
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Nothing, just send the data to the API</returns>
        public static async Task PostAppointmentAsync(Appointment appointment)
        {
            string url = $"https://petfinderadditionalapi.azurewebsites.net/api/appointment";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //serialize the C# object to a JSON object
                    string json = JsonConvert.SerializeObject(appointment);
                    //build stringContent using the json object
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    //Post the actual object
                    var response = await client.PostAsync(url, content);
                    //Check the response
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"POST the new appointment object {json} was unsuccesfull to url: {url}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Error in PostAppointmentAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
        }
        /// <summary>
        /// Makes an appointment if a user want to meet the Animal in the organization where they wan to adopt and mail the contactPerson with all the deatils
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Nothing, just send the data to the API. The ContactPerson receives a HTML mail.</returns>
        public static async Task PostMailAsync(Appointment appointment)
        {
            string url = $"https://petfinderadditionalapi.azurewebsites.net/api/mailer";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    //serialize the C# object to a JSON object
                    string json = JsonConvert.SerializeObject(appointment);
                    //build stringContent using the json object
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    //Post the actual object
                    var response = await client.PostAsync(url, content);
                    //Check the response
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"POST the new appointment object {json} was unsuccesfull to url: {url}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = $"Error in PostMailAsync in the PetRepository: {ex.Message}";
                    Debug.WriteLine(errorMsg);
                    throw new Exception(errorMsg);
                }
            }
        }

    }
}
