using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        public int ProdusId { get; set; }

        [Required]
        [StringLength(100)]
        public string Denumire { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Pret { get; set; }

        [StringLength(1000)]
        public string Descriere { get; set; }

        [Required]
        [ForeignKey("Vanzator")]
        public int VanzatorId { get; set; }

        public virtual Vanzator Vanzator
        {
            get; set;
        }
    }
}