using Interface.DTOs;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using System;

namespace Service.Service
{
    public class OfferServices : IOffer
    {
        private readonly OfferCategoryDbContext _context;

        public OfferServices(OfferCategoryDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<OfferDto>> GetAllOffers()
        {
            return await _context.Offer
                .Where(x => x.IsActive)
                .Select(x => new OfferDto
                {
                    Id = x.Id,

                    // General Information
                    OfferType = x.OfferType,
                    OfferName = x.OfferName,
                    UploadLogo = x.UploadLogo,
                    AdvertiserId = x.AdvertiserId,
                    OfferCategoryId = x.OfferCategoryId,
                    AppId = x.AppId,
                    ExternalOfferId = x.ExternalOfferId,
                    OfferPreviewUrl = x.OfferPreviewUrl,
                    OfferUrl = x.OfferUrl,
                    AdvertiserUrlBuilder = x.AdvertiserUrlBuilder,
                    LandingPage = x.LandingPage,
                    Tokens = x.Tokens,

                    // Advertiser Pricing
                    AdvertiserModel = x.AdvertiserModel,
                    AdvertiserPrice = x.AdvertiserPrice,
                    AdvertiserCurrency = x.AdvertiserCurrency,

                    // Affiliate Pricing
                    AffiliateModel = x.AffiliateModel,
                    AffiliatePrice = x.AffiliatePrice,
                    AffiliateCurrency = x.AffiliateCurrency,
                    HidePayout = x.HidePayout,

                    // Schedule
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DailyStartTime = x.DailyStartTime,
                    DailyEndTime = x.DailyEndTime,
                    DailyScheduleEnabled = x.DailyScheduleEnabled,

                    // Offer Settings
                    OfferVisibility = x.OfferVisibility,
                    Status = x.Status,
                    AlertToAffiliates = x.AlertToAffiliates,
                    DeepLinks = x.DeepLinks,

                    // Terms / Description
                    Terms = x.Terms,
                    OfferDescription = x.OfferDescription,
                    PrivateNote = x.PrivateNote,
                    PaOfferTerms = x.PaOfferTerms,
                    Styles = x.Styles,

                    // Audit
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<OfferDto> GetOfferById(int id)
        {
            return await _context.Offer
                .Where(x => x.Id == id && x.IsActive)
                .Select(x => new OfferDto
                {
                    Id = x.Id,

                    // General Information
                    OfferType = x.OfferType,
                    OfferName = x.OfferName,
                    UploadLogo = x.UploadLogo,
                    AdvertiserId = x.AdvertiserId,
                    OfferCategoryId = x.OfferCategoryId,
                    AppId = x.AppId,
                    ExternalOfferId = x.ExternalOfferId,
                    OfferPreviewUrl = x.OfferPreviewUrl,
                    OfferUrl = x.OfferUrl,
                    AdvertiserUrlBuilder = x.AdvertiserUrlBuilder,
                    LandingPage = x.LandingPage,
                    Tokens = x.Tokens,

                    // Advertiser Pricing
                    AdvertiserModel = x.AdvertiserModel,
                    AdvertiserPrice = x.AdvertiserPrice,
                    AdvertiserCurrency = x.AdvertiserCurrency,

                    // Affiliate Pricing
                    AffiliateModel = x.AffiliateModel,
                    AffiliatePrice = x.AffiliatePrice,
                    AffiliateCurrency = x.AffiliateCurrency,
                    HidePayout = x.HidePayout,

                    // Schedule
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    DailyStartTime = x.DailyStartTime,
                    DailyEndTime = x.DailyEndTime,
                    DailyScheduleEnabled = x.DailyScheduleEnabled,

                    // Offer Settings
                    OfferVisibility = x.OfferVisibility,
                    Status = x.Status,
                    AlertToAffiliates = x.AlertToAffiliates,
                    DeepLinks = x.DeepLinks,

                    // Terms / Description
                    Terms = x.Terms,
                    OfferDescription = x.OfferDescription,
                    PrivateNote = x.PrivateNote,
                    PaOfferTerms = x.PaOfferTerms,
                    Styles = x.Styles,

                    // Audit
                    CreatedOn = x.CreatedOn,
                    CreatedBy = x.CreatedBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();
        }

        // POST
        public async Task<OfferDto> CreateOffer(OfferDto dto)
        {
            var offer = new Offer
            {
                // General Information
                OfferType = dto.OfferType,
                OfferName = dto.OfferName,
                UploadLogo = dto.UploadLogo,
                AdvertiserId = dto.AdvertiserId,
                OfferCategoryId = dto.OfferCategoryId,
                AppId = dto.AppId,
                ExternalOfferId = dto.ExternalOfferId,
                OfferPreviewUrl = dto.OfferPreviewUrl,
                OfferUrl = dto.OfferUrl,
                AdvertiserUrlBuilder = dto.AdvertiserUrlBuilder,
                LandingPage = dto.LandingPage,
                Tokens = dto.Tokens,

                // Advertiser Pricing
                AdvertiserModel = dto.AdvertiserModel,
                AdvertiserPrice = dto.AdvertiserPrice,
                AdvertiserCurrency = dto.AdvertiserCurrency,

                // Affiliate Pricing
                AffiliateModel = dto.AffiliateModel,
                AffiliatePrice = dto.AffiliatePrice,
                AffiliateCurrency = dto.AffiliateCurrency,
                HidePayout = dto.HidePayout,

                // Schedule
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                DailyStartTime = dto.DailyStartTime,
                DailyEndTime = dto.DailyEndTime,
                DailyScheduleEnabled = dto.DailyScheduleEnabled,

                // Offer Settings
                OfferVisibility = dto.OfferVisibility,
                Status = dto.Status,
                AlertToAffiliates = dto.AlertToAffiliates,
                DeepLinks = dto.DeepLinks,

                // Terms / Description
                Terms = dto.Terms,
                OfferDescription = dto.OfferDescription,
                PrivateNote = dto.PrivateNote,
                PaOfferTerms = dto.PaOfferTerms,
                Styles = dto.Styles,

                // Audit
                CreatedOn = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy,
                IsActive = true
            };

            _context.Offer.Add(offer);

            await _context.SaveChangesAsync();

            dto.Id = offer.Id;
            dto.CreatedOn = offer.CreatedOn;
            dto.IsActive = offer.IsActive;

            return dto;
        }

        // PUT
        public async Task<OfferDto> UpdateOffer(
            int id,
            OfferDto dto)
        {
            var offer = await _context.Offer
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (offer == null)
            {
                return null;
            }

            // General Information
            offer.OfferType = dto.OfferType;
            offer.OfferName = dto.OfferName;
            offer.UploadLogo = dto.UploadLogo;
            offer.AdvertiserId = dto.AdvertiserId;
            offer.OfferCategoryId = dto.OfferCategoryId;
            offer.AppId = dto.AppId;
            offer.ExternalOfferId = dto.ExternalOfferId;
            offer.OfferPreviewUrl = dto.OfferPreviewUrl;
            offer.OfferUrl = dto.OfferUrl;
            offer.AdvertiserUrlBuilder = dto.AdvertiserUrlBuilder;
            offer.LandingPage = dto.LandingPage;
            offer.Tokens = dto.Tokens;

            // Advertiser Pricing
            offer.AdvertiserModel = dto.AdvertiserModel;
            offer.AdvertiserPrice = dto.AdvertiserPrice;
            offer.AdvertiserCurrency = dto.AdvertiserCurrency;

            // Affiliate Pricing
            offer.AffiliateModel = dto.AffiliateModel;
            offer.AffiliatePrice = dto.AffiliatePrice;
            offer.AffiliateCurrency = dto.AffiliateCurrency;
            offer.HidePayout = dto.HidePayout;

            // Schedule
            offer.StartDate = dto.StartDate;
            offer.EndDate = dto.EndDate;
            offer.DailyStartTime = dto.DailyStartTime;
            offer.DailyEndTime = dto.DailyEndTime;
            offer.DailyScheduleEnabled = dto.DailyScheduleEnabled;

            // Offer Settings
            offer.OfferVisibility = dto.OfferVisibility;
            offer.Status = dto.Status;
            offer.AlertToAffiliates = dto.AlertToAffiliates;
            offer.DeepLinks = dto.DeepLinks;

            // Terms / Description
            offer.Terms = dto.Terms;
            offer.OfferDescription = dto.OfferDescription;
            offer.PrivateNote = dto.PrivateNote;
            offer.PaOfferTerms = dto.PaOfferTerms;
            offer.Styles = dto.Styles;

            // Audit
            offer.ModifiedOn = DateTime.UtcNow;
            offer.ModifiedBy = dto.ModifiedBy;

            await _context.SaveChangesAsync();

            return new OfferDto
            {
                Id = offer.Id,

                OfferType = offer.OfferType,
                OfferName = offer.OfferName,
                UploadLogo = offer.UploadLogo,
                AdvertiserId = offer.AdvertiserId,
                OfferCategoryId = offer.OfferCategoryId,
                AppId = offer.AppId,
                ExternalOfferId = offer.ExternalOfferId,
                OfferPreviewUrl = offer.OfferPreviewUrl,
                OfferUrl = offer.OfferUrl,
                AdvertiserUrlBuilder = offer.AdvertiserUrlBuilder,
                LandingPage = offer.LandingPage,
                Tokens = offer.Tokens,

                AdvertiserModel = offer.AdvertiserModel,
                AdvertiserPrice = offer.AdvertiserPrice,
                AdvertiserCurrency = offer.AdvertiserCurrency,

                AffiliateModel = offer.AffiliateModel,
                AffiliatePrice = offer.AffiliatePrice,
                AffiliateCurrency = offer.AffiliateCurrency,
                HidePayout = offer.HidePayout,

                StartDate = offer.StartDate,
                EndDate = offer.EndDate,
                DailyStartTime = offer.DailyStartTime,
                DailyEndTime = offer.DailyEndTime,
                DailyScheduleEnabled = offer.DailyScheduleEnabled,

                OfferVisibility = offer.OfferVisibility,
                Status = offer.Status,
                AlertToAffiliates = offer.AlertToAffiliates,
                DeepLinks = offer.DeepLinks,

                Terms = offer.Terms,
                OfferDescription = offer.OfferDescription,
                PrivateNote = offer.PrivateNote,
                PaOfferTerms = offer.PaOfferTerms,
                Styles = offer.Styles,

                CreatedOn = offer.CreatedOn,
                CreatedBy = offer.CreatedBy,
                ModifiedOn = offer.ModifiedOn,
                ModifiedBy = offer.ModifiedBy,
                IsActive = offer.IsActive
            };
        }

        // DELETE
        public async Task<bool> DeleteOffer(int id)
        {
            var offer = await _context.Offer
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (offer == null)
            {
                return false;
            }

            // Soft Delete
            offer.IsActive = false;
            offer.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}