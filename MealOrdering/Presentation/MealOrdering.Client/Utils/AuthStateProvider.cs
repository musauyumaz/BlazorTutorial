using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MealOrdering.Client.Utils
{
    public class AuthStateProvider(ILocalStorageService _localStorageService) : AuthenticationStateProvider
    {
        private AuthenticationState anonymous = new(new(new ClaimsIdentity()));
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorageService.GetItemAsStringAsync("token");
            if (string.IsNullOrEmpty(token))
                return anonymous;

            string email = await _localStorageService.GetItemAsStringAsync("email");

            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(claims: new[] { new Claim(ClaimTypes.Email, email),}, authenticationType: "jwtAuthType"));

            return new(claimsPrincipal);
        }

        public void NotifyUserLogin(string email)
        {
            ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(claims: new[] { new Claim(ClaimTypes.Email, email), }, authenticationType: "jwtAuthType"));
            Task<AuthenticationState>? authState = Task.FromResult(new AuthenticationState(claimsPrincipal));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            Task<AuthenticationState>? authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
