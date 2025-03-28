using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_Management_Library.Utils
{
    public static class DateUtils
    {
        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }
    }
}
