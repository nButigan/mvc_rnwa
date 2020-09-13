using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RNWA_MVC.Models
{
    public class Filmovi
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage ="Obavezan unos u polje !")]
        [DisplayName("Naziv filma")]
        public string nazivFilma { get; set; }
        [Column(TypeName ="varchar(250)")]
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Kratki opis")]
        public string opis { get; set; }
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Trajanje u min.")]
        public int trajanje { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Redatelji")]
        public string redatelji { get; set; }
        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Glumci")]
        public string glumci { get; set; }
        [Required(ErrorMessage = "Obavezan unos u polje !")]
        [DisplayName("Godina")]
        public int godinaProdukcije { get; set; }
        

    }
}
