using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataModel.Master
{
    public class IndexRoomVM
    {
        public IEnumerable<ListRoomVM> Grid { get; set; } = new List<ListRoomVM>();
    }
}
