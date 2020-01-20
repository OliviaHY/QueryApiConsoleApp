using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace testconsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpoint = "http://a0f38b3c83bb811eaa5500a9645b1ed6-1733699247.us-east-1.elb.amazonaws.com/api/datetime";
            var frequecyPerSecond = 2;
            var milisecondsToWait = 1000 / frequecyPerSecond;

            Console.WriteLine($"Hi! I'm going to call {endpoint} {frequecyPerSecond} time(s) a second");

            while (true)
            {
                try
                {
                    var response = await SendRequestAsync(endpoint);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failure");
                    }
                    else
                    {
                        Console.WriteLine($"Success");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                    Console.WriteLine($"Waiting for {milisecondsToWait} miliseconds");
                    System.Threading.Thread.Sleep(milisecondsToWait);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        static private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            return httpClient;
        }

        static private async Task<HttpResponseMessage> SendRequestAsync(string url)
        {
            var httpClient = GetHttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url) { };

            return await httpClient.SendAsync(request);
        }
    }
}