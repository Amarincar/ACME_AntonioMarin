using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_Management_Library.Utils
{
    public class Validators
    {
        public static void ValidateName(string parameterToValidate, string paramName)
        {
            if (string.IsNullOrWhiteSpace(parameterToValidate))
                throw new ArgumentException($"The {paramName} can not be empty.");
        }

        public static void ValidateAdultStudent(DateTime dateOfBirth)
        {
            if (DateUtils. CalculateAge(dateOfBirth) < 18)
                throw new ArgumentException("Only adults can register.");
        }
        public static void ValidateDate(DateTime startDate, DateTime endDate)
        {
            if (endDate.Date <= startDate.Date)
                throw new ArgumentException("The end date must be later than the start date."); 
            if (startDate.Date < DateTime.Now.Date)
                throw new ArgumentException("The start date must be before than today.");
        }
        public static void ValidateRegistrationFee(decimal registrationFee)
        {
            if (registrationFee < 0)
                throw new ArgumentException("The registration fee cannot be negative.");
        }
    }
}
