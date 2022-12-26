using ConstumerShoppingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace ConstumerShoppingMVC.Controllers
{
    public class StoreController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7003/");

        HttpClient client;

        //Constructor
        public StoreController()
        {
            client = new HttpClient();

            client.BaseAddress = baseAddress;
        }

  
        //api/Product
        //Viewing all Products
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

        //api/Product/{Id}
        //Viewing Individual Product by Id.
        public async Task<IActionResult> ViewProduct(int Id)
        {
            

                ProductViewModel Model = new ProductViewModel();


                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/Products/" + Id);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    Model = JsonConvert.DeserializeObject<ProductViewModel>(data);
                }
                return View(Model);
            

        }

        //But will be viewed first and as such it behave like ViewProduct(int Id) first;
        //Editting Individual Product
        public async Task<IActionResult> EditProduct(int Id)
        {
            ProductViewModel Models = new ProductViewModel();


            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/Products/" + Id);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                Models = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View(Models);
        }

        //Close
        public IActionResult Close()
        {
            return RedirectToAction("Index");
        }

        //Updating controller
        public IActionResult UpdateProduct(ProductViewModel productViewModel)
        {

            //string data = await response.Content.ReadAsStringAsync();

            string data = JsonConvert.SerializeObject(productViewModel);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "api/Products/" + productViewModel.Id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult ShowForm()
        {
            return View();
        }

        //POST New details
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {

            string data = JsonConvert.SerializeObject(productViewModel);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "api/Products", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
