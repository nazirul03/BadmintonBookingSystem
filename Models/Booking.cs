using System;
using System.ComponentModel.DataAnnotations;

namespace BadmintonBookingSystemAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [MaxLength(100)]
        public string BookCourtNum { get; set; }

        [Required]
        [MaxLength(100)]
        public string BookDuration { get; set; }


    }
}