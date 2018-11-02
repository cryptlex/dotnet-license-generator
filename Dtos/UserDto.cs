using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotnetLicenseGenerator.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public List<string> Roles { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public List<MetadataDto> Metadata { get; set; }
    }
}