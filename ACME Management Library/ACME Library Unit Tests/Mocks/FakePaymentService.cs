using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;

namespace ACME_Library_Unit_Tests.Mocks
{
    public class FakePaymentService : IPaymentService
    {
        private readonly bool _paymentResult;

        // Constructor que permite especificar si el pago es exitoso o no.
        public FakePaymentService(bool paymentResult)
        {
            _paymentResult = paymentResult;
        }

        // Simula el proceso de pago
        public bool ProcessPayment(Student student, decimal amount)
        {
            // Aquí no hacemos ningún procesamiento real, solo devolvemos el resultado predefinido
            return _paymentResult;
        }
    }
}
