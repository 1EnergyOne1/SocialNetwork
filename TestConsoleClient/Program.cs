using System;

namespace TestConsoleClient
{
    public class Program
    {
        static HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            StringContent content = new StringContent("Tony");
            // определяем данные запроса
            using var requestPost = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7164/api/Home");
            // установка отправляемого содержимого
            requestPost.Content = content;
            // отправляем запрос
            using var responsePost = await httpClient.SendAsync(requestPost);
            // получаем ответ
            string responseText = await responsePost.Content.ReadAsStringAsync();
            Console.WriteLine(responseText);

            //using var requestGet = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7164/");

            //using var responseGet = await httpClient.GetAsync("https://localhost:7164/");

            //string responseTextGet = await responseGet.Content.ReadAsStringAsync();
            //Console.WriteLine(responseTextGet);

            Console.ReadKey();
        }
    }
}