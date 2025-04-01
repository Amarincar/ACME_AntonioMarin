using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Classes;

namespace ACME_Management_Library.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(Student student, decimal amount);
    }
}
