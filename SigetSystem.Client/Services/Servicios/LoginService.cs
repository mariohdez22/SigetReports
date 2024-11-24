using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Shared.DTOs.Independientes;
using SigetSystem.Shared.MPPs;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

namespace SigetSystem.Client.Services.Servicios
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public LoginService(IHttpClientFactory httpFactory, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<string> LogeoPersonal(LoginDTO loginDTO)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Login/Logins", loginDTO);
            var respuesta = await resultado.Content.ReadFromJsonAsync<TokenResponse>();

            if (respuesta!.CodigoEstado == HttpStatusCode.OK)
            {
                var TokenResponse = respuesta.Token;
                await _localStorage.SetItemAsync<string>("jwt-access-token", TokenResponse);
                (_authStateProvider as CustomAuthProvider).NotifyAuthState();
                return respuesta.Resultado; 
            }
            else
            {
                return "Agarra pinche cerotada";
            }
        }

        //respuesta.MensajeError ?? "Error desconocido"

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        public async Task<string> GetToken()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }

    }
}




















//var _httpClient = _httpFactory.CreateClient("ApiSiget");