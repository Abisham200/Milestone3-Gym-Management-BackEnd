using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
        Task<ICollection<Payment>> GetAllPayment();
        Task<Payment> PaymentByEnrollId(int id);
        Task<int> GetDuePaymentsCountAsync();
        Task<decimal> GetTotalAmountPaidAsync();
        Task<IEnumerable<object>> GetMonthlyPaymentsAsync();
    }
}
