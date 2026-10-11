namespace Interface.DTOs
{
    public class AccessLog
    {
        public long Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? AccessBy { get; set; }
        public long? EmployeeId { get; set; }
        public string? Location { get; set; }
        public string? LogData { get; set; }
        public string? UserInfo { get; set; }
        public bool? IsActive { get; set; }
    }
}
