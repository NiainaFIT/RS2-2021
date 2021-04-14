using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class KorisniciUpdateRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(20)]
        public string Ime { get; set; }
        [MaxLength(50)]
        public string Prezime { get; set; }
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Telefon { get; set; }
        [Required(AllowEmptyStrings = false)]
        //public string KorisnickoIme { get; set; }
        //[Required(AllowEmptyStrings = false)]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        //[DataType(DataType.Password)]
        //public string Lozinka { get; set; }
        public bool? Status { get; set; }
    }
}
