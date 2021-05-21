using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinWebService.Repository;

namespace XamarinWebService.Services
{
    public class PersonRestService
    {
        HttpClient _client;

        public PersonRestService()
        {
            _client = new HttpClient();
        }

        public async Task<PersonRepository.Root> GetPersonsAsync(string uri)
        {
            PersonRepository.Root person = new PersonRepository.Root();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    person = JsonConvert.DeserializeObject<PersonRepository.Root>(content);

                    for (int i = 0; i < person.Results.Count; i++)
                    {
                        Debug.WriteLine(person.Results[i].Name.First);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return person;
        }    
    }
}
