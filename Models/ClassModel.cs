using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestZadatak2.Models
{
    public class ClassModel
    {
        [Display(Name = "Ime")]     
        public string Ime
        {
            get;
            set;
        }
        [Display(Name = "Prezime")]
        public string Prezime
        {
            get; set;

        }
        [Display(Name = "Adresa")]
        public string Adresa
        {
            get; set;
        }

        [Display(Name = "Neto")]
        public string Neto
        {
            get; set;
        }

        [Display(Name = "Bruto")]
        public string Bruto
        {
            get; set;
        }

       public string Radnik_PIO
        {
            get; set;
        }
        
        public string Radnik_ZO
        {
            get; set;
        }

        public string Radnik_Nezaposlenost
        {
            get; set;
        }

        public string Poslodavac_PIO
        {
            get; set;
        }

        public string Poslodavac_ZO
        {
            get; set;
        }
    }
}