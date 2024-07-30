using BookingSystem.DataModel.Master;
using BookingSystem.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCodeController : ControllerBase
    {
        private BookingCodeProvider BCProvider;
        public BookingCodeController(BookingCodeProvider BCProvider)
        {
            this.BCProvider = BCProvider;
        }
        [HttpPost]
        public IActionResult CreateEditBC(CreateEditBCVM model)
        {
            try
            {
                if (model.ID == 0 || model.ID == null)
                {
                    BCProvider.InsertBC(model);
                    return Ok();
                }
                else
                {
                    BCProvider.UpdateBC(model);
                    return Ok();
                }

            } catch (Exception ex)
            {
                return StatusCode(500, new { error = "Terjadi kesalahan dalam pemrosesan data." });
            }
        }


        [HttpDelete]
        public IActionResult DeleteBC(int id)
        {
            BCProvider.DeleteBC(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetIndexBC()
        {
            var bc = BCProvider.IndexBC();
            return Ok(bc);
        }

    }
}
