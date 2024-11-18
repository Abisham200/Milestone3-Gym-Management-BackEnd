﻿using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymFeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;

        }

        [HttpPost("AddPayment")]

        public async Task<IActionResult> AddPayment(PaymentRequestDTO paymentRequest)
        {
            try
            {
                var data = await _paymentService.AddPayment(paymentRequest);
                return Ok(data);

            }
            catch(Exception ex) 
            {
            return BadRequest(ex.Message);
            }
        }
    }
}
