using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Interfaces;

namespace ACME_Management_Library.Classes
{
    internal class PaymentService : IPaymentGateway
    {
        public bool ProcessPayment(Student student, decimal amount)
        {
            // TODO : Hacer pasarela de pago??
            //Console.WriteLine($"Processing payment of {amount:C} for student {student.Name}...");
            return true; 
        }
    }
}
