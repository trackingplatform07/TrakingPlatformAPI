using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }

        // General Information
        public string? OfferType { get; set; }
        public string? OfferName { get; set; }
        public string? UploadLogo { get; set; }

        public int? AdvertiserId { get; set; }
        public int? OfferCategoryId { get; set; }

        public string? AppId { get; set; }
        public string? ExternalOfferId { get; set; }
        public string? OfferPreviewUrl { get; set; }
        public string? OfferUrl { get; set; }
        public string? AdvertiserUrlBuilder { get; set; }
        public string? LandingPage { get; set; }
        public string? Tokens { get; set; }

        // Advertiser Pricing
        public string? AdvertiserModel { get; set; }
        public decimal? AdvertiserPrice { get; set; }
        public string? AdvertiserCurrency { get; set; }

        // Affiliate Pricing
        public string? AffiliateModel { get; set; }
        public decimal? AffiliatePrice { get; set; }
        public string? AffiliateCurrency { get; set; }
        public bool? HidePayout { get; set; }

        // Schedule
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? DailyStartTime { get; set; }
        public TimeSpan? DailyEndTime { get; set; }
        public bool? DailyScheduleEnabled { get; set; }

        // Offer Settings
        public string? OfferVisibility { get; set; }
        public string? Status { get; set; }
        public bool? AlertToAffiliates { get; set; }
        public bool? DeepLinks { get; set; }

        // Terms / Description
        public string? Terms { get; set; }
        public string? OfferDescription { get; set; }
        public string? PrivateNote { get; set; }
        public string? PaOfferTerms { get; set; }
        public string? Styles { get; set; }

        // Audit Columns
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
