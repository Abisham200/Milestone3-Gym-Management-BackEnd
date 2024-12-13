using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IPaymentService
    {
        Task<Payment> AddPayment(PaymentRequestDTO paymentRequest);
        Task<ICollection<Payment>> GetAllPayment();
        Task<Payment> PaymentByEnrollId(int id);
        Task<int> GetDuePaymentsCountAsync();
        Task<decimal> GetTotalAmountPaidAsync();
        Task<IEnumerable<object>> GetMonthlyPaymentsAsync();


    }
}
