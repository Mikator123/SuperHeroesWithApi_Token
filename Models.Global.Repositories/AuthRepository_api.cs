﻿using Model.Interfaces;
using Models.Global.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Models.Global.Repositories
{
    public class AuthRepository_api : IAuthRepository<UserGlobal>
    {
        private Uri _baseAddress;

        public AuthRepository_api()
        {
            _baseAddress = new Uri("https://localhost:44324/api/");
        }
        public UserGlobal Login(string login, string password)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress; // recrupere l'adresse du Web.api -> propriété -> Web // ajouter /api/ a la fin
                httpClient.DefaultRequestHeaders.Accept.Clear(); // clear la propriété accept du httpClient
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // défini le type voulu

                string jsonContent = JsonConvert.SerializeObject(new { Login = login, Password = password });
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
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress; // recrupere l'adresse du Web.api -> propriété -> Web // ajouter /api/ a la fin
                httpClient.DefaultRequestHeaders.Accept.Clear(); // clear la propriété accept du httpClient
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // défini le type voulu

                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"Auth/Register", httpContent).Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération

            }
        }
    }
}
