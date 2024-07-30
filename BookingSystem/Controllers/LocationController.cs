using BookingSystem.DataModel.Master;
using BookingSystem.Provider;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    public class LocationController : Controller
    {

        private readonly LocationProvider _locProvider;

        public LocationController(LocationProvider locProvider)
        {
            _locProvider = locProvider;
        }

        [HttpPost]
        public IActionResult CreateEditLoc(CreateEditLocVM model)
        {
            try
            {
                _locProvider.Save(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Terjadi kesalahan dalam pemrosesan data." });
            }
        }
    }
}
