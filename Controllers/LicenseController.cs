using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using DotnetLicenseGenerator.Dtos;
using DotnetLicenseGenerator.Services;

namespace DotnetLicenseGenerator.Controllers
{
    [Route("api/licenses")]
    public class LicenseController : ControllerBase
    {
        private string accessToken = "PASTE_PERSONAL_ACCESS_TOKEN"; // with permissions user:write, license:read & license:write
        private string productId = "PASTE_PRODUCT_ID";

        [HttpPost("create-license")]
        public async Task<ActionResult> CreateLicense(PaypalDto paypalDto)
        {
            if (paypalDto.PaymentStatus == "Completed" && paypalDto.VendorEmail == "PASTE_YOUR_PAYPAL_EMAIL")
            {
                var licenseService = new LicenseService(accessToken);
                
                // optionally you can create a user
                var user = new
                {
                    firstName = paypalDto.FirstName,
                    lastName = paypalDto.LastName,
                    email = paypalDto.Email,
                    role = "user",
                    password = new Guid().ToString()
                };
                var userDto = await licenseService.CreateUser(JsonConvert.SerializeObject(user));

                var license = new
                {
                    productId = productId,
                    userId = userDto.Id,
                    metadata = new List<MetadataDto>()
                };

                // optionally you can store some metadata
                license.metadata.Add(new MetadataDto() { key = "payer_id", value = paypalDto.PayerId, visible = true });

                var licenseDto = await licenseService.CreateLicense(JsonConvert.SerializeObject(license));
                return Ok(new { key = licenseDto.Key });
            }
            return BadRequest();
        }

        [HttpPost("renew-license")]
        public async Task<ActionResult> RenewLicense(PaypalDto paypalDto)
        {
            if (paypalDto.PaymentStatus == "Completed" && paypalDto.VendorEmail == "PASTE_YOUR_PAYPAL_EMAIL")
            {
                var licenseService = new LicenseService(accessToken);
                var license = await licenseService.RenewLicense(productId, paypalDto.Custom);
                return Ok(new { message = "License renewed successfully!" });
            }
            return BadRequest();
        }
    }
}
