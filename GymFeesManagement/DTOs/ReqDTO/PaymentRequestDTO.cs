﻿using GymFeesManagement.Entities;

namespace GymFeesManagement.DTOs.ReqDTO
{
    public class PaymentRequestDTO
    {
        public decimal Amount { get; set; }
    //    public DateTime Date { get; set; }
        public int EntrollmentId { get; set; }
       
    }
}
