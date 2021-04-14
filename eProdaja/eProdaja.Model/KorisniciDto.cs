using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class KorisniciDto
    {
        public KorisniciDto()
        {
           // KorisniciUloges = new HashSet<KorisniciUloge>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool? Status { get; set; }
        //public virtual ICollection<KorisniciUlogeDto> KorisniciUloges { get; set; }
    }
}
