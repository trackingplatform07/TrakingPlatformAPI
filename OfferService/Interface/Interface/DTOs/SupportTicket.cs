namespace Interface.DTOs
{
    public class SupportTicket
    {
        public long Id { get; set; }
        public int TicketNumber { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;
        public string? AttachmentFileName { get; set; }
        public string Status { get; set; } = "Open";
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
