using BookingSystem.DataModel.Master;
using BookingSystem.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomProvider _roomProvider;

        public RoomController(RoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
        }


        [HttpPost]
        public IActionResult CreateEditRoom(CreateEditRoomVM model)
        {
            try
            {
                _roomProvider.Save(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Terjadi kesalahan dalam pemrosesan data." });
            }
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            _roomProvider.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetIndex() 
        {
            var room = _roomProvider.GetIndexRoom();
            return Ok(room);
        }
    }
}
