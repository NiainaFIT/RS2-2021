using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class KorisniciInsertRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(20)]
        public string Ime { get; set; }
        [MaxLength(50)]
        public string Prezime { get; set; }
        [EmailAddress(ErrorMessage ="Adresa mora biti u formatu xxxx@xxxx.xxx")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Telefon { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(18, ErrorMessage = "Lozinka: minimalno {0}, maksimalno {1} karaktera.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{6,30}$", ErrorMessage ="Lozinka mora sadržavati malo i veliko slovo, specijalni znak, broj,min 6 i max 30 karaktera")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        
        [Required(ErrorMessage = "Potvrdi lozinku")]
        [DataType(DataType.Password)]
        [Compare("Lozinka",ErrorMessage ="Lozinke se ne slažu")]
        public string LozinkaPotvrdi { get; set; }
        public List<int> Uloge { get; set; }
    }
}
