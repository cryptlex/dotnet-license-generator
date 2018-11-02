using System;
using System.Collections.Generic;

namespace DotnetLicenseGenerator.Dtos
{
    public class LicenseDto : BaseDto
    {
        public string Key { get; set; }

        public bool Revoked { get; set; }

        public bool Suspended { get; set; }

        public int TotalActivations { get; set; }

        public int TotalDeactivations { get; set; }

        public int Validity { get; set; }

        public string ExpirationStrategy { get; set; }

        public string FingerprintMatchingStrategy { get; set; }

        public int AllowedActivations { get; set; }

        public int AllowedDeactivations { get; set; }

        public string Type { get; set; }

        public int AllowedFloatingClients { get; set; }

        public int ServerSyncGracePeriod { get; set; }

        public int ServerSyncInterval { get; set; }

        public int AllowedClockOffset { get; set; }

        public int LeaseDuration { get; set; }

        public DateTime? ExpiresAt { get; set; }

        public bool AllowVmActivation { get; set; }

        public bool UserLocked { get; set; }

        public string ProductId { get; set; }

        public List<string> AllowedCountries { get; set; }

        public List<string> DisallowedCountries { get; set; }

        public List<string> AllowedIpAddresses { get; set; }

        public List<string> DisallowedIpAddresses { get; set; }

        public List<MetadataDto> Metadata { get; set; }

        public List<string> Tags { get; set; }

    }
}