using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
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
            CreateMap<JediniceMjere, JediniceMjereDto>();
            CreateMap<VrsteProizvodum, VrsteProizvodaDto>();
            CreateMap<Proizvodi, ProizvodiDto>();
            CreateMap<ProizvodiInsertRequestDto, Proizvodi>();
            CreateMap<ProizvodiUpdateRequestDto, Proizvodi>();
            CreateMap<UlogeDto, Uloge>();
            CreateMap<KorisniciUlogeDto, KorisniciUloge>();
            CreateMap<KorisniciInsertRequestDto,Korisnici>();
            CreateMap<KorisniciUpdateRequestDto, Korisnici>();

        }
    }
}
