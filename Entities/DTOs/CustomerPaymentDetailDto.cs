using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerPaymentDetailDto : IDtos
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string expirationDate { get; set; }
    }
}