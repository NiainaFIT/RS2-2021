using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;
        public KorisniciService(eProdajaContext context, IMapper mapper )
        {
            Context = context;
            _mapper = mapper;
        }
        public List<KorisniciDto> Get()
        {
            return Context.Korisnicis.ToList().Select(x=>_mapper.Map<KorisniciDto>(x)).ToList();
        }

        public KorisniciDto Insert(KorisniciInsertRequest request)
        {
            throw new UserException("Lozinka nije ispravna");
        }

        //private KorisniciDto ToModel(Korisnici entity)
        //{
        //    return new KorisniciDto()
        //    {
        //        KorisnikId=entity.KorisnikId,
        //        Ime=entity.Ime,
        //        Prezime=entity.Prezime,
        //        KorisnickoIme=entity.KorisnickoIme,
        //        Email=entity.Email,
        //        Telefon=entity.Telefon
        //    };
        //}
    }
}
