using BookingSystem.DataAccess.Models;
using BookingSystem.DataModel.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingSystem.Provider
{
    public class BookingCodeProvider : BaseService
    {
        private BookingSystemContext _context;
        public BookingCodeProvider(BookingSystemContext context)
        {
            this._context = context;
        }

        private IQueryable AllBookingCode()
        {
            return _context.MstBookingCodes.Where(a => !a.DelDate.HasValue);
        }

        private MstBookingCode Get(int id)
        {
            return _context.MstBookingCodes.SingleOrDefault(a => a.Id == id);
        }
        public void InsertBC(CreateEditBCVM model)
        {
            var newBC = new MstBookingCode();
            newBC.Id = model.ID;
            newBC.BookingCode = model.BookingCode;
            newBC.Status = model.IsActive;
            newBC.CreatedBy = 1;
            newBC.CreatedDate = DateTime.Now;
            _context.MstBookingCodes.Add(newBC);
            _context.SaveChanges();
        }

        public void UpdateBC(CreateEditBCVM model)
        {
            var bc = Get(model.ID);
            bc.BookingCode = model.BookingCode;
            bc.Status = model.IsActive;
            bc.UpdatedBy = 2;
            bc.UpdatedDate = DateTime.Now;
            _context.SaveChanges();

        }

        public void DeleteBC(int id)
        {
            var bc = Get(id);
            bc.DelDate = DateTime.Now;
            bc.DelBy = 3;
            _context.SaveChanges();
        }
        public IndexBCVM IndexBC()
        {
            var bc = new IndexBCVM();
            using (var dbContext = new BookingSystemContext())
            {
                var query = from bookingCode in dbContext.MstBookingCodes
                            select new ListBCVM()
                            {
                                Id = bookingCode.Id,
                                BookingCode = bookingCode.BookingCode,
                                IsActive = bookingCode.Status
                            };
                bc.Grid = query.ToList();
            }
            return bc;
        }
    }
}
