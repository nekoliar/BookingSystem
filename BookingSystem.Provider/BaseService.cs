using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Provider
{
    public abstract class BaseService
    {
        protected const int _totalPage = 10;

        protected static int GetSkip(int page)
        {
            return (page - 1) * _totalPage;
        }
        protected static int GetTotalPages(int totalRows)
        {
            var decimalResult = (double)totalRows / (double)_totalPage;
            return (int)Math.Ceiling(decimalResult);
        }
    }
}
