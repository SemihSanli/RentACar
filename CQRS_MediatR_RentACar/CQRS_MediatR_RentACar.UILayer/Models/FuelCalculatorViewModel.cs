using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CQRS_MediatR_RentACar.UILayer.Models
{
    public class FuelCalculatorViewModel
    {
        [Display(Name = "Başlangıç Lokasyonu")]
        [Required]
        public int? OriginLocationId { get; set; }

        [Display(Name = "Varış Lokasyonu")]
        [Required]
        public int? DestinationLocationId { get; set; }

        [Display(Name = "Tahmini Mesafe (km)")]
        public double? ManualDistanceKm { get; set; }

        [Display(Name = "Ortalama Tüketim")]
        public decimal? ConsumptionLPer100Km { get; set; } = 8.0m;

        [Display(Name = "Yakıt Fiyatı")]
        public decimal? ManualFuelPrice { get; set; }

        [Display(Name = "Yakıt Türü")]
        [Required]
        public string FuelType { get; set; } = "gasoline"; // gasoline | diesel | lpg

        [Display(Name = "Gidiş-Dönüş")]
        public bool IsRoundTrip { get; set; }

        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();

        // Original fields for backward compatibility
        public double? DistanceKm { get; set; }
        public decimal? PricePerLiter { get; set; }
        public decimal? EstimatedCost { get; set; }
        public string? Currency { get; set; }
        public string? Message { get; set; }

        // New result fields for the design
        public double? TotalDistanceKm { get; set; }
        public decimal? TotalFuelLiters { get; set; }
        public int? EstimatedTimeHours { get; set; }
    }
}
