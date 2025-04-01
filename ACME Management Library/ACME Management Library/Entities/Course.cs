using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;
using ACME_Management_Library.Utils;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal RegistrationFee { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    private readonly List<Student> _students = new();
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    public Course(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
    {
        Validators.ValidateName(name, "course name");
        Validators.ValidateRegistrationFee(registrationFee);
        Validators.ValidateDate(startDate, endDate);

        Id = Guid.NewGuid();
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void EnrollStudent(Student student, IPaymentService paymentService)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }
        if (_students.Contains(student)) 
        { 
            throw new InvalidOperationException("Student is already enrolled in this course."); 
        }

        if (RegistrationFee > 0)
        {
            bool paymentSuccessful = paymentService.ProcessPayment(student, RegistrationFee);
            if (!paymentSuccessful)
            {
                throw new InvalidOperationException("Payment failed. Enrollment denied.");
            }
        }

        _students.Add(student);
    }
}