using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 202; i++)
            {
                var bytes = DownloadFile($"https://vs1.coursehunters.net/coursename/lesson{i}.mp4").GetAwaiter().GetResult();
                File.WriteAllBytes($"C:\\mosh\\lesson{i}.mp4", bytes);
            }
        }


        public static async Task<byte[]> DownloadFile(string url)
        {
            using (var client = new HttpClient())
            {

                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsByteArrayAsync();
                    }

                }
            }
            return null;
        }
    }
}
