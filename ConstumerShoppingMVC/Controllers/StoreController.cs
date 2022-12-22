using ConstumerShoppingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace ConstumerShoppingMVC.Controllers
{
    public class StoreController : Controller
    {
        //HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri("https://localhost:7003/");  

        Uri baseAddress = new Uri("https://localhost:7003/");

        HttpClient client;

        public StoreController()
        {
            client = new HttpClient();

            client.BaseAddress = baseAddress;
        }

  

        public async Task<IActionResult> Index()
        
        {
            List<ProductViewModel> Modellist = new List<ProductViewModel>();

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/Products");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                Modellist = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }

            return View(Modellist);
        }
    }
}
