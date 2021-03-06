﻿using Model.Interfaces;
using Models.Global.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace Models.Global.Repositories
{
    public class SuperHeroRepository_api : ICRUDRepository<SuperHeroGlobal>
    {
        private readonly Uri _baseAddress;

        private readonly string _token;
        public SuperHeroRepository_api(string token)
        {
            _token = token;
            _baseAddress = new Uri("https://localhost:44324/api/");
        }
        public void Create(SuperHeroGlobal entity)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"SuperHeroes", httpContent).Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération
            }
        }

        public void Delete(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"SuperHeroes/{id}").Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération
            }
        }

        public IEnumerable<SuperHeroGlobal> GetAll()
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"SuperHeroes").Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération

                string result = httpResponseMessage.Content.ReadAsStringAsync().Result; // donne le résultat du body de l'enveloppe
                return JsonConvert.DeserializeObject<SuperHeroGlobal[]>(result); //(désérialise l'objet pour l'envoyer côté client)
            }
        }

        public SuperHeroGlobal GetById(int id)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"SuperHeroes/{id}").Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération

                string result = httpResponseMessage.Content.ReadAsStringAsync().Result; // donne le résultat du body de l'enveloppe
                return JsonConvert.DeserializeObject<SuperHeroGlobal>(result); //(désérialise l'objet pour l'envoyer côté client)
            }
        }

        public void Update(SuperHeroGlobal entity)
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(entity);
                HttpContent httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"SuperHeroes/{entity.Id}", httpContent).Result; //donne le résult de l'enveloppe (header/body)
                httpResponseMessage.EnsureSuccessStatusCode(); //vérifie qu'il n'y ai pas d'erreur dans la récupération

            }
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = _baseAddress; // recrupere l'adresse du Web.api -> propriété -> Web // ajouter /api/ a la fin
            httpClient.DefaultRequestHeaders.Accept.Clear(); // clear la propriété accept du httpClient
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // défini le type voulu
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token); // vérifie le token
            
            return httpClient;
            
        }
    }
}

