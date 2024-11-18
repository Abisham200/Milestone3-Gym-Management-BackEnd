using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;

namespace GymFeesManagement.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;

       public PaymentRepository(AppDbContext appDbContext) 
        {
        _appDbContext = appDbContext;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            var data = await _appDbContext.Payments.AddAsync(payment);
            await _appDbContext.SaveChangesAsync();
            return data.Entity;
        }
    }
}
