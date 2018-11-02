using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetLicenseGenerator.Dtos
{
    public class MetadataDto
    {
        public string key { get; set; }
        public string value { get; set; }
        public bool visible { get; set; }
    }
}