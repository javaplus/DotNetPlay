using System;
using unirest_net.http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace myApp
{
    class Program
    {

    private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
           /* Console.WriteLine("Hello World!");
            Console.WriteLine("The current time is " + DateTime.Now);
            HttpResponse<string> response = Unirest.get("http://localhost:8080/hello")
              .header("X-RapidAPI-Host", "microsoft-azure-translation-v1.p.rapidapi.com")
              .header("X-RapidAPI-Key", "<YOUR_RAPID_API_KEY>")
              .header("Accept", "application/json")
              .asJson<string>();
          Console.WriteLine(response.Body.ToString());*/

          await CallHello();
        }


        private static async Task CallHello()
        {           
            var streamTask = client.GetStreamAsync("http://host.docker.internal:8080/hello");
            var person = await JsonSerializer.DeserializeAsync<Person>(await streamTask);
            Console.WriteLine(person.name);
            Console.WriteLine(person.city);

        }

    }
}
