using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Classes;

namespace ACME_Management_Library.Interfaces
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(Student student, decimal amount);
    }
    public class MockPaymentGateway : IPaymentGateway
    {
        bool IPaymentGateway.ProcessPayment(Student student, decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C} for student {student.Name}...");
            // Simula un pago exitoso
            return true;
        }
    }
}
