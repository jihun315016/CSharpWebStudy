using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SharedLib;

namespace WebClient.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserModel userModel)
    {
        string result;
        TokenResponse tokenResponse;
        
        string url = "https://localhost:7219/api/Account/Login";
        HttpClient client = new HttpClient();
        var response = await client.PostAsJsonAsync<UserModel>(url, userModel);
        if (response.IsSuccessStatusCode) 
        {
            result = await response.Content.ReadAsStringAsync();
            tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(result);
            return View("Success", tokenResponse.Token);
        }
        else
        {
            result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        return View();
    }
}

