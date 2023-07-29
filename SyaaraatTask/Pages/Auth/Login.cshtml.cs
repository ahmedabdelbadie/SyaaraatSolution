using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Task.PersonAddress.DTO.DTOs;

namespace SyaaraatTask.WEB.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public async void OnPostAsync()
        {
            string Baseurl = "https://localhost:7037/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    StringContent content = new StringContent(JsonConvert.SerializeObject(new UserToLoginDTO()
                    {
                        Email = Email,
                        Password = Password
                    }), Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(Baseurl);

                    HttpResponseMessage response = await client.PostAsync("api/v2/Auth/login", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        //API call success, Do your action
                    }

                    else
                    {
                        //API Call Failed, Check Error Details
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async void OnPostCallAPI()
        {
            string Baseurl = "https://localhost:44309/WeatherForecast";

            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = new Uri(Baseurl);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("SecureApiKey", "12345");
                    HttpResponseMessage response = await client.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        //API call success, Do your action
                    }

                    else
                    {
                        //API Call Failed, Check Error Details
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
