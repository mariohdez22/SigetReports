using Blazored.LocalStorage;
using SigetSystem.Client.Services.Interfaces;

namespace SigetSystem.Client.Services.Servicios
{
    public class UsuarioService
    {
        public event Action OnUserStateChanged;
        private readonly ILocalStorageService _localStorage;
        private readonly ILoginService _loginService;

        public UsuarioService(ILocalStorageService localStorage, ILoginService loginService)
        {
            _localStorage = localStorage;
            _loginService = loginService;
        }

        public bool IsUserAuthenticated { get; private set; }
        public string UserRole { get; private set; }

        public async Task UpdateUserAuthenticationStatus()
        {
            var userRole = await _localStorage.GetItemAsync<string>("userRole");
            if (!string.IsNullOrEmpty(userRole))
            {
                IsUserAuthenticated = true;
                UserRole = userRole;
                NotifyStateChanged();
            }
        }

        public void NotifyStateChanged() => OnUserStateChanged?.Invoke();

        public void LogOut()
        {
            _loginService.Logout();
            IsUserAuthenticated = false;
            UserRole = null;
            OnUserStateChanged?.Invoke();
        }
    }
}
