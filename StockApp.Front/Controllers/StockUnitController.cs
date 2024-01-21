using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApp.Front.Modals;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockApp.Front.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class StockUnitController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StockUnitController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("https://localhost:7038/api/StockUnits");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<StockUnitListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    var stockTypeList = await GetStockTypes();
                    foreach (var item in result)
                    {
                        item.StockTypeCode = stockTypeList.FirstOrDefault(x => x.Id == item.StockTypeId)?.Name;
                    }
                    return View(result);
                }
            }

            return View();
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var dd = await client.DeleteAsync($"https://localhost:7038/api/StockUnits/{id}");
            }

            return RedirectToAction("List");
        }
        private async Task<List<LookupModel>> GetStockTypes()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("https://localhost:7038/api/StockTypes");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<LookupModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return result;
                }
            }

            return new List<LookupModel>();
        }
        public async Task<IActionResult> Create()
        {
            var stockTypeList = await GetStockTypes(); // Assuming this method returns List<StockTypeLookupModel>

            var model = new CreateStockUnitModel
            {

                StockTypeList = stockTypeList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList() ?? new List<SelectListItem>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockUnitModel model)
        {
            if (ModelState.IsValid)
            {
                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://localhost:7038/api/StockUnits", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bir hata oluştu");
                    }

                }
            }
            return View(model);
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7038/api/StockUnits/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<StockUnitListModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return View(result);
                }
            }

            return RedirectToAction("List");
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7038/api/StockUnits/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<StockUnitListModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    var stockTypeList = await GetStockTypes();
                    var updateModel = new StockUnitListModel
                    {
                        Id = result.Id,
                        Code = result.Code,
                        Description = result.Description,
                        Type = result.Type,
                        StockTypeId = result.StockTypeId,
                        BuyingPrice = result.BuyingPrice,
                        BuyingCurrency = result.BuyingCurrency,
                        SellingCurrency = result.SellingCurrency,
                        SellingPrice = result.SellingPrice,
                        PaperWeight = result.PaperWeight,
                        Approval = result.Approval,
                        StockTypeList = stockTypeList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList() ?? new List<SelectListItem>(),
                    };
                    return View(result);
                }
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockUnitListModel model)
        {
            if (ModelState.IsValid)
            {
                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync("https://localhost:7038/api/StockUnits", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bir hata oluştu");
                    }

                }
            }
            return View(model);
        }
    }
}
