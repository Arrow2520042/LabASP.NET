using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("reservations")]
    public class ReservationEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string RoomName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Owner { get; set; }

        [Column("price")] 
        public decimal? Price { get; set; }

        [Column("reservation_date")]
        public DateTime? Date { get; set; }
    }
}