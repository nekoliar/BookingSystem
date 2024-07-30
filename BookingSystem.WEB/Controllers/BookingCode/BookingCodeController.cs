using BookingSystem.DataModel.Master;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace BookingSystem.WEB.Controllers.Booking_Code
{
    public class BookingCodeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BookingCodeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexBCVM();
            var client = httpClientFactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5289/api/BookingCode");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                try
                {
                    model = JsonSerializer.Deserialize<IndexBCVM>(responseString, options);
                }
                catch (JsonException ex)
                {
                    return View("Error", ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            var model = new CreateEditBCVM();
            var client = httpClientFactory.CreateClient();

            if (Id.HasValue)
            {
                    var requestUrl = $"{"http://localhost:5289/api/BookingCode"}/{Id.Value}";
                    var response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        try
                        {
                            //model = JsonSerializer.Deserialize<IndexBCVM>(content, options);
                        }
                        catch (JsonException ex)
                        {
                            return View("Error", ex.Message);
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Unable to retrieve the record.";
                    }
                }
            return View(model);
            }

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Upsert(CreateEditBCVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var httpClient = _httpClientFactory.CreateClient();
        //    HttpResponseMessage response;

        //    try
        //    {
        //        if (model.BookingID != 0 && model.BookingID != null)
        //        {
        //            // Update existing booking
        //            response = await httpClient.PutAsJsonAsync($"{_apiBaseUrl}/upsert", model);
        //        }
        //        else
        //        {
        //            // Create new booking
        //            response = await httpClient.PostAsJsonAsync($"{_apiBaseUrl}/upsert", model);
        //        }

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index"); // Redirect ke halaman lain setelah berhasil
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Failed to save data.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = $"An error occurred: {ex.Message}";
        //    }

        //    return View(model);
        //}

    
}
