﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataModel.Master
{
    public class ListRoomVM
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Floor {  get; set; }
        public string? Description { get; set; }
        public int LocationId { get; set; }
        public int Capacity { get; set; }
        public string RoomColor { get; set; }
    }
}
