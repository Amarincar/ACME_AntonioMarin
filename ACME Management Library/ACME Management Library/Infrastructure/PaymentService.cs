using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;

namespace ACME_Management_Library.Infrastructure
{
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(Student student, decimal amount)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (amount <= 0)
                return true; // Si el curso es gratis, el pago es exitoso por defecto.

            // Simulación de pago: Se asume que el pago siempre es exitoso.
            Console.WriteLine($"Processing payment of {amount:C} for student {student.Name} {student.LastName}");
            return true;
        }
    }
}
