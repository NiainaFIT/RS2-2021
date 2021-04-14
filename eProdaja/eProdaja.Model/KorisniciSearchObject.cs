using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class KorisniciSearchObject
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string [] IncludeList { get; set; }
    }
}
