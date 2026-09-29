using System;

namespace Interface.DTOs
{
    public class NetworkSettingDTO
    {
        public long Id { get; set; }

        public string NetworkName { get; set; } = string.Empty;
        public string? LoginPlatformDomain { get; set; }
        public string? CustomLoginPlatformDomain { get; set; }

        public string? LoginAccessTypes { get; set; }

        public string? Timezone { get; set; }
        public string? Currency { get; set; }
        public string? Language { get; set; }

        public long? DefaultAffiliateManagerUserId { get; set; }
        public long? DefaultAdvertiserManagerUserId { get; set; }

        public string? EmployeeDashboardCustomization { get; set; }

        public string? CustomPrivacyPolicy { get; set; }
        public string? TermsAndConditions { get; set; }
        public string? CustomTermsAndConditionsTitle { get; set; }
        public string? CustomTermsAndConditionsBody { get; set; }
        public string? OfferDefaultTermsAndConditions { get; set; }

        public string? TrackingDomain { get; set; }
        public string? CustomTrackingDomain { get; set; }
        public string? DefaultTrackingProtocol { get; set; }
        public string? DefaultTrackingDomain { get; set; }
        public string? ConversionsOutOfAllowedCountries { get; set; }
        public string? LandingPageMismatch { get; set; }
        public string? GlobalFallbackUrl { get; set; }
        public string? IpSource { get; set; }
        public string? ClickIpv4FilterMode { get; set; }
        public string? ClickIpv4FilterRanges { get; set; }
        public string? PostbackErrorAlertEmail { get; set; }
        public int? PostbackErrorThreshold { get; set; }
        public string? DefaultTrackingLinkTokens { get; set; }
        public bool TrackingLinkPreviewEnabled { get; set; }
        public long? TestAffiliateId { get; set; }
        public string? TestIps { get; set; }
        public string? DefaultUniqueIdFields { get; set; }
        public bool DataMaskingDeviceId { get; set; }
        public bool DataMaskingIpAddress { get; set; }
        public string? AppsFlyerClickSigningMode { get; set; }
        public string? AppsFlyerAccessKey { get; set; }
        public long? ClickSigningAdvertiserId { get; set; }

        public string? FavoriteIconDataUrl { get; set; }
        public string? LogoSmallDataUrl { get; set; }
        public string? AdminProfileImageDataUrl { get; set; }
        public string? InvoiceSignatureDataUrl { get; set; }

        public string? TerminologyAffiliate { get; set; }
        public string? TerminologyOffer { get; set; }
        public string? TerminologyAdvertiser { get; set; }
        public string? TerminologyReport { get; set; }
        public string? TerminologyConversion { get; set; }
        public string? TerminologyIGamingUser { get; set; }

        public string? FontStyle { get; set; }

        public string? ChatTicketProvider { get; set; }
        public string? ChatTicketAccessKey1 { get; set; }
        public string? ChatTicketAccessKey2 { get; set; }
        public string? ChatTicketAccessKey3 { get; set; }

        public string? AffiliatePlatformTheme { get; set; }
        public string? AffiliateDefaultLanguage { get; set; }
        public string? HttpReferral { get; set; }
        public bool ReferralCommissionEnabled { get; set; }
        public string? ReferralCommissionType { get; set; }
        public int? ReferralCommissionDays { get; set; }
        public string? ReferralCommissionValue { get; set; }
        public string? ReferralTerms { get; set; }
        public string? AffiliatePaymentMethods { get; set; }
        public string? AffiliateInvoiceCc { get; set; }
        public string? AffiliateReportsDisplay { get; set; }
        public string? AffiliatePayoutDisplay { get; set; }
        public string? ReportFieldsCustomization { get; set; }
        public string? PostbackTokenCustomization { get; set; }
        public bool AffiliateImpressionUrlEnabled { get; set; }
        public bool AffiliateSignUpEnabled { get; set; }
        public string? SignUpApproval { get; set; }
        public string? SignupFieldsCustomization { get; set; }
        public string? SignupMessengerTypes { get; set; }
        public bool SignupQuestionsEnabled { get; set; }
        public bool SignupQuestionsAllowMultiple { get; set; }
        public string? SignupQuestionsJson { get; set; }

        public string? AdvertiserPaymentMethods { get; set; }
        public string? AdvertiserInvoiceCc { get; set; }
        public bool AdvertiserSignUpEnabled { get; set; }
        public string? AdvertiserSignUpApproval { get; set; }
        public string? AdvertiserSignupFieldsCustomization { get; set; }
        public string? AdvertiserSignupMessengerTypes { get; set; }
        public string? AdvertiserReportFieldsCustomization { get; set; }

        public string? NotificationSettingsJson { get; set; }
        public string? NotificationPrefix { get; set; }
        public string? TelegramBotToken { get; set; }
        public string? TelegramChatId { get; set; }
        public string? SlackWebhookUrl { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
