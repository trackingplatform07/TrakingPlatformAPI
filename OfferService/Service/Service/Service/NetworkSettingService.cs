using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;

namespace Service.Services
{
    public class NetworkSettingService : INetworkSetting
    {
        private readonly OfferCategoryDbContext _context;

        public NetworkSettingService(OfferCategoryDbContext context)
        {
            _context = context;
        }

        private static NetworkSettingDTO ToDto(NetworkSetting x) => new NetworkSettingDTO
        {
            Id = x.Id,

            NetworkName = x.NetworkName,
            LoginPlatformDomain = x.LoginPlatformDomain,
            CustomLoginPlatformDomain = x.CustomLoginPlatformDomain,

            LoginAccessTypes = x.LoginAccessTypes,

            Timezone = x.Timezone,
            Currency = x.Currency,
            Language = x.Language,

            DefaultAffiliateManagerUserId = x.DefaultAffiliateManagerUserId,
            DefaultAdvertiserManagerUserId = x.DefaultAdvertiserManagerUserId,

            EmployeeDashboardCustomization = x.EmployeeDashboardCustomization,

            CustomPrivacyPolicy = x.CustomPrivacyPolicy,
            TermsAndConditions = x.TermsAndConditions,
            CustomTermsAndConditionsTitle = x.CustomTermsAndConditionsTitle,
            CustomTermsAndConditionsBody = x.CustomTermsAndConditionsBody,
            OfferDefaultTermsAndConditions = x.OfferDefaultTermsAndConditions,

            TrackingDomain = x.TrackingDomain,
            CustomTrackingDomain = x.CustomTrackingDomain,
            DefaultTrackingProtocol = x.DefaultTrackingProtocol,
            DefaultTrackingDomain = x.DefaultTrackingDomain,
            ConversionsOutOfAllowedCountries = x.ConversionsOutOfAllowedCountries,
            LandingPageMismatch = x.LandingPageMismatch,
            GlobalFallbackUrl = x.GlobalFallbackUrl,
            IpSource = x.IpSource,
            ClickIpv4FilterMode = x.ClickIpv4FilterMode,
            ClickIpv4FilterRanges = x.ClickIpv4FilterRanges,
            PostbackErrorAlertEmail = x.PostbackErrorAlertEmail,
            PostbackErrorThreshold = x.PostbackErrorThreshold,
            DefaultTrackingLinkTokens = x.DefaultTrackingLinkTokens,
            TrackingLinkPreviewEnabled = x.TrackingLinkPreviewEnabled,
            TestAffiliateId = x.TestAffiliateId,
            TestIps = x.TestIps,
            DefaultUniqueIdFields = x.DefaultUniqueIdFields,
            DataMaskingDeviceId = x.DataMaskingDeviceId,
            DataMaskingIpAddress = x.DataMaskingIpAddress,
            AppsFlyerClickSigningMode = x.AppsFlyerClickSigningMode,
            AppsFlyerAccessKey = x.AppsFlyerAccessKey,
            ClickSigningAdvertiserId = x.ClickSigningAdvertiserId,

            FavoriteIconDataUrl = x.FavoriteIconDataUrl,
            LogoSmallDataUrl = x.LogoSmallDataUrl,
            AdminProfileImageDataUrl = x.AdminProfileImageDataUrl,
            InvoiceSignatureDataUrl = x.InvoiceSignatureDataUrl,

            TerminologyAffiliate = x.TerminologyAffiliate,
            TerminologyOffer = x.TerminologyOffer,
            TerminologyAdvertiser = x.TerminologyAdvertiser,
            TerminologyReport = x.TerminologyReport,
            TerminologyConversion = x.TerminologyConversion,
            TerminologyIGamingUser = x.TerminologyIGamingUser,

            FontStyle = x.FontStyle,

            ChatTicketProvider = x.ChatTicketProvider,
            ChatTicketAccessKey1 = x.ChatTicketAccessKey1,
            ChatTicketAccessKey2 = x.ChatTicketAccessKey2,
            ChatTicketAccessKey3 = x.ChatTicketAccessKey3,

            AffiliatePlatformTheme = x.AffiliatePlatformTheme,
            AffiliateDefaultLanguage = x.AffiliateDefaultLanguage,
            HttpReferral = x.HttpReferral,
            ReferralCommissionEnabled = x.ReferralCommissionEnabled,
            ReferralCommissionType = x.ReferralCommissionType,
            ReferralCommissionDays = x.ReferralCommissionDays,
            ReferralCommissionValue = x.ReferralCommissionValue,
            ReferralTerms = x.ReferralTerms,
            AffiliatePaymentMethods = x.AffiliatePaymentMethods,
            AffiliateInvoiceCc = x.AffiliateInvoiceCc,
            AffiliateReportsDisplay = x.AffiliateReportsDisplay,
            AffiliatePayoutDisplay = x.AffiliatePayoutDisplay,
            ReportFieldsCustomization = x.ReportFieldsCustomization,
            PostbackTokenCustomization = x.PostbackTokenCustomization,
            AffiliateImpressionUrlEnabled = x.AffiliateImpressionUrlEnabled,
            AffiliateSignUpEnabled = x.AffiliateSignUpEnabled,
            SignUpApproval = x.SignUpApproval,
            SignupFieldsCustomization = x.SignupFieldsCustomization,
            SignupMessengerTypes = x.SignupMessengerTypes,
            SignupQuestionsEnabled = x.SignupQuestionsEnabled,
            SignupQuestionsAllowMultiple = x.SignupQuestionsAllowMultiple,
            SignupQuestionsJson = x.SignupQuestionsJson,

            AdvertiserPaymentMethods = x.AdvertiserPaymentMethods,
            AdvertiserInvoiceCc = x.AdvertiserInvoiceCc,
            AdvertiserSignUpEnabled = x.AdvertiserSignUpEnabled,
            AdvertiserSignUpApproval = x.AdvertiserSignUpApproval,
            AdvertiserSignupFieldsCustomization = x.AdvertiserSignupFieldsCustomization,
            AdvertiserSignupMessengerTypes = x.AdvertiserSignupMessengerTypes,
            AdvertiserReportFieldsCustomization = x.AdvertiserReportFieldsCustomization,

            NotificationSettingsJson = x.NotificationSettingsJson,
            NotificationPrefix = x.NotificationPrefix,
            TelegramBotToken = x.TelegramBotToken,
            TelegramChatId = x.TelegramChatId,
            SlackWebhookUrl = x.SlackWebhookUrl,

            CreatedOn = x.CreatedOn,
            CreatedBy = x.CreatedBy,

            ModifiedOn = x.ModifiedOn,
            ModifiedBy = x.ModifiedBy,

            IsActive = x.IsActive
        };

        private async Task<NetworkSetting> EnsureExistsAsync()
        {
            var entity = await _context.NetworkSettings.FirstOrDefaultAsync();
            if (entity != null) return entity;

            entity = new NetworkSetting
            {
                NetworkName = "Demo",
                LoginAccessTypes = "Employee,Affiliate,Advertiser",
                Timezone = "(GMT +0:00) UTC, Western Europe Time, London, Lisbon, Casablanca",
                Currency = "USD",
                Language = "English (EN)",
                DefaultTrackingProtocol = "HTTPS",
                ConversionsOutOfAllowedCountries = "Pending",
                LandingPageMismatch = "Redirect to Offer URL",
                IpSource = "X Forwarded For (server side)",
                ClickIpv4FilterMode = "Allow",
                PostbackErrorThreshold = 10,
                DefaultTrackingLinkTokens = "aff_click_id,sub_aff_id",
                DefaultUniqueIdFields = "OfferID,IP4/6",
                AppsFlyerClickSigningMode = "Disable Click Signing",
                TerminologyAffiliate = "Affiliate",
                TerminologyOffer = "Offer",
                TerminologyAdvertiser = "Advertiser",
                TerminologyReport = "Report",
                TerminologyConversion = "Conversion",
                TerminologyIGamingUser = "User",
                ChatTicketProvider = "Tawk.to",
                AffiliatePlatformTheme = "Default",
                ReferralCommissionType = "Percentage",
                ReferralCommissionDays = 90,
                ReferralCommissionValue = "10",
                AffiliateReportsDisplay = "Approved",
                AffiliatePayoutDisplay = "Approved,Pending,Rejected,Hold",
                AffiliateImpressionUrlEnabled = true,
                AffiliateSignUpEnabled = true,
                SignUpApproval = "Pending (after signup)",
                SignupQuestionsJson = "[]",
                AdvertiserSignUpEnabled = true,
                AdvertiserSignUpApproval = "Auto Approve (after signup)",
                NotificationSettingsJson = "{}",
                NotificationPrefix = "Production",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            _context.NetworkSettings.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<NetworkSettingDTO> GetAsync()
        {
            var entity = await EnsureExistsAsync();
            return ToDto(entity);
        }

        public async Task<NetworkSettingDTO> UpdateAsync(NetworkSettingDTO dto)
        {
            var entity = await EnsureExistsAsync();

            entity.NetworkName = dto.NetworkName;
            entity.LoginPlatformDomain = dto.LoginPlatformDomain;
            entity.CustomLoginPlatformDomain = dto.CustomLoginPlatformDomain;

            entity.LoginAccessTypes = dto.LoginAccessTypes;

            entity.Timezone = dto.Timezone;
            entity.Currency = dto.Currency;
            entity.Language = dto.Language;

            entity.DefaultAffiliateManagerUserId = dto.DefaultAffiliateManagerUserId;
            entity.DefaultAdvertiserManagerUserId = dto.DefaultAdvertiserManagerUserId;

            entity.EmployeeDashboardCustomization = dto.EmployeeDashboardCustomization;

            entity.CustomPrivacyPolicy = dto.CustomPrivacyPolicy;
            entity.TermsAndConditions = dto.TermsAndConditions;
            entity.CustomTermsAndConditionsTitle = dto.CustomTermsAndConditionsTitle;
            entity.CustomTermsAndConditionsBody = dto.CustomTermsAndConditionsBody;
            entity.OfferDefaultTermsAndConditions = dto.OfferDefaultTermsAndConditions;

            entity.TrackingDomain = dto.TrackingDomain;
            entity.CustomTrackingDomain = dto.CustomTrackingDomain;
            entity.DefaultTrackingProtocol = dto.DefaultTrackingProtocol;
            entity.DefaultTrackingDomain = dto.DefaultTrackingDomain;
            entity.ConversionsOutOfAllowedCountries = dto.ConversionsOutOfAllowedCountries;
            entity.LandingPageMismatch = dto.LandingPageMismatch;
            entity.GlobalFallbackUrl = dto.GlobalFallbackUrl;
            entity.IpSource = dto.IpSource;
            entity.ClickIpv4FilterMode = dto.ClickIpv4FilterMode;
            entity.ClickIpv4FilterRanges = dto.ClickIpv4FilterRanges;
            entity.PostbackErrorAlertEmail = dto.PostbackErrorAlertEmail;
            entity.PostbackErrorThreshold = dto.PostbackErrorThreshold;
            entity.DefaultTrackingLinkTokens = dto.DefaultTrackingLinkTokens;
            entity.TrackingLinkPreviewEnabled = dto.TrackingLinkPreviewEnabled;
            entity.TestAffiliateId = dto.TestAffiliateId;
            entity.TestIps = dto.TestIps;
            entity.DefaultUniqueIdFields = dto.DefaultUniqueIdFields;
            entity.DataMaskingDeviceId = dto.DataMaskingDeviceId;
            entity.DataMaskingIpAddress = dto.DataMaskingIpAddress;
            entity.AppsFlyerClickSigningMode = dto.AppsFlyerClickSigningMode;
            entity.AppsFlyerAccessKey = dto.AppsFlyerAccessKey;
            entity.ClickSigningAdvertiserId = dto.ClickSigningAdvertiserId;

            entity.FavoriteIconDataUrl = dto.FavoriteIconDataUrl;
            entity.LogoSmallDataUrl = dto.LogoSmallDataUrl;
            entity.AdminProfileImageDataUrl = dto.AdminProfileImageDataUrl;
            entity.InvoiceSignatureDataUrl = dto.InvoiceSignatureDataUrl;

            entity.TerminologyAffiliate = dto.TerminologyAffiliate;
            entity.TerminologyOffer = dto.TerminologyOffer;
            entity.TerminologyAdvertiser = dto.TerminologyAdvertiser;
            entity.TerminologyReport = dto.TerminologyReport;
            entity.TerminologyConversion = dto.TerminologyConversion;
            entity.TerminologyIGamingUser = dto.TerminologyIGamingUser;

            entity.FontStyle = dto.FontStyle;

            entity.ChatTicketProvider = dto.ChatTicketProvider;
            entity.ChatTicketAccessKey1 = dto.ChatTicketAccessKey1;
            entity.ChatTicketAccessKey2 = dto.ChatTicketAccessKey2;
            entity.ChatTicketAccessKey3 = dto.ChatTicketAccessKey3;

            entity.AffiliatePlatformTheme = dto.AffiliatePlatformTheme;
            entity.AffiliateDefaultLanguage = dto.AffiliateDefaultLanguage;
            entity.HttpReferral = dto.HttpReferral;
            entity.ReferralCommissionEnabled = dto.ReferralCommissionEnabled;
            entity.ReferralCommissionType = dto.ReferralCommissionType;
            entity.ReferralCommissionDays = dto.ReferralCommissionDays;
            entity.ReferralCommissionValue = dto.ReferralCommissionValue;
            entity.ReferralTerms = dto.ReferralTerms;
            entity.AffiliatePaymentMethods = dto.AffiliatePaymentMethods;
            entity.AffiliateInvoiceCc = dto.AffiliateInvoiceCc;
            entity.AffiliateReportsDisplay = dto.AffiliateReportsDisplay;
            entity.AffiliatePayoutDisplay = dto.AffiliatePayoutDisplay;
            entity.ReportFieldsCustomization = dto.ReportFieldsCustomization;
            entity.PostbackTokenCustomization = dto.PostbackTokenCustomization;
            entity.AffiliateImpressionUrlEnabled = dto.AffiliateImpressionUrlEnabled;
            entity.AffiliateSignUpEnabled = dto.AffiliateSignUpEnabled;
            entity.SignUpApproval = dto.SignUpApproval;
            entity.SignupFieldsCustomization = dto.SignupFieldsCustomization;
            entity.SignupMessengerTypes = dto.SignupMessengerTypes;
            entity.SignupQuestionsEnabled = dto.SignupQuestionsEnabled;
            entity.SignupQuestionsAllowMultiple = dto.SignupQuestionsAllowMultiple;
            entity.SignupQuestionsJson = dto.SignupQuestionsJson;

            entity.AdvertiserPaymentMethods = dto.AdvertiserPaymentMethods;
            entity.AdvertiserInvoiceCc = dto.AdvertiserInvoiceCc;
            entity.AdvertiserSignUpEnabled = dto.AdvertiserSignUpEnabled;
            entity.AdvertiserSignUpApproval = dto.AdvertiserSignUpApproval;
            entity.AdvertiserSignupFieldsCustomization = dto.AdvertiserSignupFieldsCustomization;
            entity.AdvertiserSignupMessengerTypes = dto.AdvertiserSignupMessengerTypes;
            entity.AdvertiserReportFieldsCustomization = dto.AdvertiserReportFieldsCustomization;

            entity.NotificationSettingsJson = dto.NotificationSettingsJson;
            entity.NotificationPrefix = dto.NotificationPrefix;
            entity.TelegramBotToken = dto.TelegramBotToken;
            entity.TelegramChatId = dto.TelegramChatId;
            entity.SlackWebhookUrl = dto.SlackWebhookUrl;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
