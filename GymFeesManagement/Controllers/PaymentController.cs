using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.IServices;
using GymFeesManagement.Services;
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

        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var data = await _paymentService.GetAllPayment();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPaymentByEnrollId/{id}")]
        public async Task<IActionResult> PaymentByEnrollId(int id)
        {
            try
            {
                var data = await _paymentService.PaymentByEnrollId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("duePaymentsCount")]
        public async Task<ActionResult<int>> GetDuePaymentsCount()
        {
            try
            {
                var count = await _paymentService.GetDuePaymentsCountAsync();
                return Ok(count);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("getTotalPaidAmount")]
        public async Task<ActionResult<decimal>> GetTotalAmountPaid()
        {
            try
            {
                var totalAmountPaid = await _paymentService.GetTotalAmountPaidAsync();
                return Ok(totalAmountPaid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("MonthlyPayments")]
        public async Task<IActionResult> GetMonthlyPayments()
        {
            var monthlyPayments = await _paymentService.GetMonthlyPaymentsAsync();
            return Ok(monthlyPayments);
        }

    }
}
