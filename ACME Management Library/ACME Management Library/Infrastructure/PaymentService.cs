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
                return true; //If course is free, payment will be success buy default.

            // Pay simulation: Success by default.
            Console.WriteLine($"Processing payment of {amount:C} for student {student.Name} {student.LastName}");
            return true;
        }
    }
}
