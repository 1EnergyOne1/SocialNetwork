using System;
using System.Net.Http.Json;

namespace TestConsoleClient
{
    public class Program
    {
        static HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            int[] family = { (28), (27), (3) };
            StringContent content = new StringContent("Tony");
            // определяем данные запроса
            //Передача данных в методе POST. Передача в запросе
            //using var requestPost = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7164/api/users/AddUser?name=Mari&lastName=Boyko&age=27");

            JsonContent jsonContent = JsonContent.Create(family);
            //Передача данных в запросе и теле
            using var requestPost = await httpClient.PostAsync("https://localhost:7164/api/users/AddUser?name=Mari&lastName=Boyko&age=27", jsonContent);
            // установка отправляемого содержимого
            //requestPost.Content = content;
            // отправляем запрос
           //using var responsePost = await httpClient.SendAsync(requestPost);
           var responsePost = await requestPost.Content.ReadFromJsonAsync<bool>();
            // получаем ответ
            /*string responseText = await responsePost.Content.ReadAsStringAsync()*/;
            Console.WriteLine(responsePost);

            //using var requestGet = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7164/");

            //using var responseGet = await httpClient.GetAsync("https://localhost:7164/");

            //string responseTextGet = await responseGet.Content.ReadAsStringAsync();
            //Console.WriteLine(responseTextGet);
        }
    }
}