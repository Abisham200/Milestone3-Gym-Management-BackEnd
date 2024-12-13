using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;
using GymFeesManagement.Repositories;

namespace GymFeesManagement.Services
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> AddPayment(PaymentRequestDTO paymentRequest)
        {
            var payment = new Payment
            {
                Amount = paymentRequest.Amount,
                Date = DateTime.Now,
                EntrollmentId = paymentRequest.EntrollmentId,
                
            };

            return await _paymentRepository.AddPayment(payment);

        }

        public async Task<ICollection<Payment>> GetAllPayment()
        {
            return await _paymentRepository.GetAllPayment();
        }

        public async Task<Payment> PaymentByEnrollId(int id)
        {
            return await _paymentRepository.PaymentByEnrollId(id);
        }

        public async Task<int> GetDuePaymentsCountAsync()
        {
            return await _paymentRepository.GetDuePaymentsCountAsync();
        }


        public async Task<decimal> GetTotalAmountPaidAsync()
        {
            return await _paymentRepository.GetTotalAmountPaidAsync();
        }

        public async Task<IEnumerable<object>> GetMonthlyPaymentsAsync()
        {
            return await _paymentRepository.GetMonthlyPaymentsAsync();
        }
    }
   
}
