using BookingSystem.DataAccess.Models;
using BookingSystem.DataModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider
{
    public class RoomProvider
    {
        private readonly BookingSystemContext _context;

        public RoomProvider(BookingSystemContext context)
        {
            this._context = context;
        }
        private IQueryable AllRoom()
        {
            return _context.MstRooms.Where(a => !a.DelDate.HasValue);
        }
        private MstRoom Get(int id)
        {
            return _context.MstRooms.SingleOrDefault(a => a.RoomId == id);
        }
        public CreateEditRoomVM Save(CreateEditRoomVM model)
        {
            if (model.Id > 0)
            {
                //UpdateMode
                using (var dbContext = new BookingSystemContext())
                {
                    var entity = Get(model.Id);
                    entity.RoomId = model.Id;
                    entity.RoomName = model.RoomName;
                    entity.Floor = model.Floor;
                    entity.Description = model.Description;
                    entity.LocationId = model.LocationID;
                    entity.Capacity = model.Capacity;
                    entity.RoomColor = model.RoomColor;
                    entity.UpdatedBy = 2;
                    entity.UpdatedDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
            } else
            {
                //InsertMode
                var entity = new MstRoom
                {
                    RoomId = model.Id,
                    RoomName = model.RoomName,
                    Floor = model.Floor,
                    Description = model.Description,
                    LocationId = model.LocationID,
                    Capacity = model.Capacity,
                    RoomColor = model.RoomColor,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                };
                MstRoom result;
                using (var dbContext = new BookingSystemContext())
                {
                    result = dbContext.MstRooms.Add(entity).Entity;
                    dbContext.SaveChanges();
                    model.Id = result.RoomId;
                }
            }
            return model;
        }

        public void Delete(int roomId)
        {
            var room = Get(roomId);
            room.DelBy = 3;
            room.DelDate = DateTime.Now;
            _context.SaveChanges();
        }

        public IndexRoomVM GetIndexRoom()
        {
            var room = new IndexRoomVM();
            using (var dbContext = new BookingSystemContext())
            {
                var query = from mstRoom in dbContext.MstRooms
                            select new ListRoomVM()
                            {
                                Id = mstRoom.RoomId,
                                RoomName = mstRoom.RoomName,
                                Floor = mstRoom.Floor,
                                LocationId = mstRoom.LocationId,
                                Description = mstRoom.Description,
                                Capacity = mstRoom.Capacity,
                                RoomColor = mstRoom.RoomColor,
                            };
                room.Grid = query.ToList();
            }
            return room;
        }
    }
}
