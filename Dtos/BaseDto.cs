using System;
using System.Collections.Generic;

namespace DotnetLicenseGenerator.Dtos
{
    public class BaseDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}