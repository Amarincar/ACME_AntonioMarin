using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;

namespace ACME_Library_Unit_Tests.Mocks
{
    public class FakePaymentService : IPaymentService
    {
        private readonly bool _paymentResult;

        public FakePaymentService(bool paymentResult)
        {
            _paymentResult = paymentResult;
        }

        public bool ProcessPayment(Student student, decimal amount)
        {
            return _paymentResult;
        }
    }
}
