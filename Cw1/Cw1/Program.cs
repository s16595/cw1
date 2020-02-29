using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(args[0]);

            Regex rx = new Regex("[A-Za-z\\d]+@([A-Za-z\\d]+\\.)+[A-Za-z\\d]{2,}");

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var text = await response.Content.ReadAsStringAsync();

                MatchCollection matches = rx.Matches(text);

                foreach(Match m in matches)
                {
                    Console.WriteLine(m.Value);
                }
            }
            else
            {
                Console.WriteLine("Code: " + response.StatusCode);
            }

           
        }
    }
}
