using Model.Interfaces;
using Models.Global.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Models.Global.Repositories
{
    class AuthRepository_api : IAuthRepository<UserGlobal>
    {
        public UserGlobal Login(UserGlobal entity)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44305/api/"); // recrupere l'adresse du Web.api -> propriété -> Web
                httpClient.DefaultRequestHeaders.Accept.Clear(); // clear la propriété accept du httpClient
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // défini le type voulu

                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"Auth/Login", httpContent).Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération

                string result = httpResponseMessage.Content.ReadAsStringAsync().Result; // donne le résultat du body de l'enveloppe
                return JsonConvert.DeserializeObject<UserGlobal>(result); //(désérialise l'objet pour l'envoyer côté client)
            }
        }

        public void Register(UserGlobal entity)
        {

        }
    }
}
