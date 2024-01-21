using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using StockApp.Front.Modals;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockApp.Front.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class StockCardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StockCardController(IHttpClientFactory httpClientFactory)
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

                var response = await client.GetAsync("https://localhost:7038/api/StockCards");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<StockCardListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    // Retrieve lookup data
                    var stockTypeList = await GetStockTypes();
                    var stockUnitList = await GetStockUnits();

                    // Update each item in the result list with lookup data
                    foreach (var item in result)
                    {
                        item.StockTypeCode = stockTypeList.FirstOrDefault(x => x.Id == item.StockTypeId)?.Name;
                        item.StockUnitDescription = stockUnitList.FirstOrDefault(x => x.Id == item.StockUnitId)?.Description;
                    }

                    return View(result);
                }
            }

            return View();
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7038/api/StockCards/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<StockCardListModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return View(result);
                }
            }

            return RedirectToAction("List");
        }
        public async Task<IActionResult> Remove(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var dd = await client.DeleteAsync($"https://localhost:7038/api/StockCards/{id}");
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
        private async Task<List<LookupModel>> GetStockUnits()
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
            var stockUnitList = await GetStockUnits(); // Assuming this method returns List<StockTypeLookupModel>
           
           var model = new CreateStockCardModel
            {
               
               StockTypeList = stockTypeList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList() ?? new List<SelectListItem>(),
         StockUnitList=stockUnitList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Description }).ToList() ?? new List<SelectListItem>()
           };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockCardModel model)
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

                    var response = await client.PostAsync("https://localhost:7038/api/StockCards", content);

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


        public async Task<IActionResult> Update(Guid id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7038/api/StockCards/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<StockCardListModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    // Retrieve lookup data
                    var stockTypeList = await GetStockTypes();
                    var stockUnitList = await GetStockUnits();

                    // Create the update model and populate lookup lists
                    var updateModel = new StockCardListModel
                    {
                        Id = result.Id,
                        Code = result.Code,
                        ProductType = result.ProductType,
                        Description = result.Description,
                        StockTypeId = result.StockTypeId,
                        StockUnitId = result.StockUnitId,
                        ShelfInformation = result.ShelfInformation,
                        CabinetInformation = result.CabinetInformation,
                        Amount = result.Amount,
                        CriticalQuantity = result.CriticalQuantity,
                        StockTypeList = stockTypeList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList() ?? new List<SelectListItem>(),
                        StockUnitList = stockUnitList?.Select(x => new SelectListItem { Value = x.Id, Text = x.Description }).ToList() ?? new List<SelectListItem>()
                    };

                    return View(updateModel);
                }
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockCardListModel model)
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

                    var response = await client.PutAsync("https://localhost:7038/api/StockCards", content);

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
