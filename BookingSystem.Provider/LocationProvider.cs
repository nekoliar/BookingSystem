using BookingSystem.DataAccess.Models;
using BookingSystem.DataModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider
{
    public class LocationProvider
    {
        private readonly BookingSystemContext _context;

        public LocationProvider(BookingSystemContext context)
        {
            _context = context;
        }

        private MstLocation Get(int id)
        {
            return _context.MstLocations.SingleOrDefault(a => a.Id == id);
        }

        public CreateEditLocVM Save(CreateEditLocVM model)
        {
            if (model.Id > 0)
            {
                //Update Mode
                using(var dbContext = new BookingSystemContext())
                {
                    var entity = Get(model.Id);
                    entity.LocationName = model.Name;
                    entity.UpdatedBy = 2;
                    entity.UpdatedDate = DateTime.Now;
                    dbContext.SaveChanges();
                }
            } else
            {
                //Insert Mode
                var entity = new MstLocation
                {
                    Id = model.Id,
                    LocationName = model.Name,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                };
                MstLocation result;
                using(var dbContext = new BookingSystemContext())
                {
                    result = dbContext.MstLocations.Add(entity).Entity;
                    dbContext.SaveChanges();
                    model.Id = result.Id;
                }
            }
            return model;
        }
    }
}
