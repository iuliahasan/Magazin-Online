using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class OfertePretNegociabil
    {
        [Key]
        public int OfertaId { get; set; }

        [Required]
        [ForeignKey("Produs")]
        public int ProdusId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CumparatorId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Oferta { get; set; }

        [Required]
        public DateTime DataOferta { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Stare { get; set; }

        public virtual Produs Produs { get; set; }
        public virtual User Cumparator { get; set; }
    }
}