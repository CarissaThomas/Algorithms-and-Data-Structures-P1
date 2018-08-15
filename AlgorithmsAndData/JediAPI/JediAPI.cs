using AlgorithmsAndData.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndData.JediAPI
{
    public class JediAPI
    {
      static HttpClient client = new HttpClient();

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
