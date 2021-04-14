using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class ProizvodiDto
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool? Status { get; set; }

        public virtual JediniceMjereDto JedinicaMjere { get; set; }
        public virtual VrsteProizvodaDto Vrsta { get; set; }
        //public virtual ICollection<IzlazStavke> IzlazStavkes { get; set; }
        //public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
        //public virtual ICollection<Ocjene> Ocjenes { get; set; }
        //public virtual ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}
