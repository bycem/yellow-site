using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models.Orders
{
    public class MakePaymentModel
    {
        [FromBody]
        [Required]
        public decimal Amount { get; set; }

        [FromBody]
        public bool IsSuccess { get; set; }
    }
}
