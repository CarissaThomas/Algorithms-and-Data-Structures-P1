using AlgorithmsAndData.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndData.JediAPI
{
    public class JediAPI
    {
      static HttpClient client = new HttpClient();


      public static async Task<List<Models.Jedi>> GetAllJedis()//Return all Jedis
      {
         try
         {
            List<Jedi> jediDeserialized = new List<Jedi>();

            var _Data = new Dictionary<Jedi, JArray>();

            AllJedis jedi = new AllJedis();

            HttpResponseMessage response = await client.GetAsync("https://swapi.co/api/people/");

            if (response.IsSuccessStatusCode)
            {
               jedi = await response.Content.ReadAsAsync<AllJedis>();

               int counter = 1;

               var jediIDs = jedi.Results//Give each jedi object an ID to be used with algorithms 
                  .Select(x => x.ID = counter++)
                  .ToList();

               string jsonstring = JsonConvert.SerializeObject(jedi.Results);

               jediDeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Jedi>>(jsonstring);

            }
            return jediDeserialized;

         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
            throw;
         }

         

      }

      public static async Task<Models.Jedi> GetJedis(double ID)
      {

         Jedi jedi = null;

         HttpResponseMessage response = await client.GetAsync("https://swapi.co/api/people/" +  ID);

         if (response.IsSuccessStatusCode)
         {
            jedi = await response.Content.ReadAsAsync<Jedi>();
         }

         return jedi;
      }

   }
}
