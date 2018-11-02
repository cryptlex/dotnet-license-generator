using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLicenseGenerator.Dtos
{
    public class PaypalDto
    {
        
        [Required]
        [FromQuery(Name = "first_name")]
        public string FirstName { get; set; }

        [Required]
        [FromQuery(Name = "last_name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [FromQuery(Name = "payer_email")]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [FromQuery(Name = "receiver_email")]
        public string VendorEmail { get; set; }

        [Required]
        [FromQuery(Name = "payment_status")]
        public string PaymentStatus { get; set; }

        [Required]
        [FromQuery(Name = "payer_id")]
        public string PayerId { get; set; }

        [Required]
        [FromQuery(Name = "custom")]
        public string Custom { get; set; }

    }
}