using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ICollection<Payment>> GetAllPayment()
        {
            return await _appDbContext.Payments.ToListAsync();
        }

        public async Task<Payment> PaymentByEnrollId(int id)
        {
            var payment = await _appDbContext.Payments.SingleOrDefaultAsync(d => d.EntrollmentId == id);
            if (payment == null)
            {
                throw new Exception();
            }

            return payment;
        }
    }
}
