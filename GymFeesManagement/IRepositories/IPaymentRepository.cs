using GymFeesManagement.Entities;

namespace GymFeesManagement.IRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPayment(Payment payment);
    }
}
