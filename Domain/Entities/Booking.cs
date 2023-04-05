using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int ArtisanId {get; set;}
        public Artisan Artisan {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public string Reason {get; set;}
        public decimal Cost {get; set;}
        public BookingStatus BookingStatus {get; set;}
        public PaymentStatus PaymentStatus {get; set;}
        public bool IsApproved {get; set;}
        public DateTime BookingDate {get; set;}
        public DateTime EndBookingDate {get; set;}
    }
}