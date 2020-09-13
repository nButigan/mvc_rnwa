using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RNWA_MVC.Models
{
    public class Zanrovi
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Naziv žanra")]
        public string nazivZanra { get; set; }
    }
}
