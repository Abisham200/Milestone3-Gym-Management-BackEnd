﻿using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;

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
                Date = paymentRequest.Date,
                EntrollmentId = paymentRequest.EntrollmentId
            };

            return await _paymentRepository.AddPayment(payment);

        }
    }
   
}