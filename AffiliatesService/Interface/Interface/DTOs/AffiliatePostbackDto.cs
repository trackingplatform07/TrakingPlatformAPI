using System;
using System.Collections.Generic;

namespace Interface.DTOs
{
    public class AffiliatePostbackDto
    {
        public int Id { get; set; }
        public string? AffiliateId { get; set; }
        public string? AffiliateName { get; set; }
        public string? Position { get; set; }
        public string? OfferId { get; set; }
        public string? EventType { get; set; }
        public string? IntegrationType { get; set; }
        public string? Type { get; set; }
        public string? PostbackURL { get; set; }
        public string? Status { get; set; }
        public string? TriggerType { get; set; }
        public DateTime? UpdateTime { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }

    public class CreateAffiliatePostbackDto
    {
        public string? AffiliateId { get; set; }
        public string? AffiliateName { get; set; }
        public string? Position { get; set; }
        public string? OfferId { get; set; }
        public string? EventType { get; set; }
        public string? IntegrationType { get; set; }
        public string? Type { get; set; }
        public string? PostbackUrl { get; set; }
        public string? Status { get; set; }
        public string? TriggerType { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class UpdateAffiliatePostbackDto
    {
        public string? AffiliateId { get; set; }
        public string? AffiliateName { get; set; }
        public string? Position { get; set; }
        public string? OfferId { get; set; }
        public string? EventType { get; set; }
        public string? IntegrationType { get; set; }
        public string? Type { get; set; }
        public string? PostbackUrl { get; set; }
        public string? Status { get; set; }
        public string? TriggerType { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public class UpdatePostbackStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? ModifiedBy { get; set; }
    }
}