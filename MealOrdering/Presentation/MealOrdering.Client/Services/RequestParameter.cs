using System.Net.Http.Headers;

namespace MealOrdering.Client.Services
{
    public class RequestParameter
    {
        public RequestParameter(string? controller, string? action)
        {
            Controller = controller;
            Action = action;
        }
        public string Controller { get; set; }
        public string? Action { get; set; }
        public string? QueryString { get; set; }
        public HttpHeaders? HttpHeaders { get; set; }
        public string? BaseUrl { get; set; }
        public string? FullEndPoint { get; set; }
    }
}
