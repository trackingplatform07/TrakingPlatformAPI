using System;

namespace Interface.DTOs
{
    public class SmtpSettingDTO
    {
        public long Id { get; set; }

        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FromEmail { get; set; }
        public string? FromName { get; set; }
        public bool UseSsl { get; set; } = true;
        public string EncryptionMode { get; set; } = "SSL";

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }

    public class SmtpConnectionTestResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
