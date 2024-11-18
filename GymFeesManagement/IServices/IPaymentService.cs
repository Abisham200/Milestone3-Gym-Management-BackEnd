using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;

namespace GymFeesManagement.IServices
{
    public interface IPaymentService
    {
        Task<Payment> AddPayment(PaymentRequestDTO paymentRequest);
    }
}
