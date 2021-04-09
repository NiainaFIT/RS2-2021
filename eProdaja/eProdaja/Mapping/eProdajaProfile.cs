using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Mapping
{
    public class eProdajaProfil:Profile
    {
        public eProdajaProfil()
        {
            CreateMap<Korisnici, KorisniciDto>();
        }
    }
}
