using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Helpers;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;
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

        public KorisniciService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        //public List<KorisniciDto> Get()
        //{
        //    return Context.Korisnicis.ToList().Select(x=>_mapper.Map<KorisniciDto>(x)).ToList();
        //}

        //public KorisniciDto Insert(KorisniciInsertRequest request)
        //{
        //    throw new UserException("Lozinka nije ispravna");
        //}

        ////private KorisniciDto ToModel(Korisnici entity)
        ////{
        ////    return new KorisniciDto()
        ////    {
        ////        KorisnikId=entity.KorisnikId,
        ////        Ime=entity.Ime,
        ////        Prezime=entity.Prezime,
        ////        KorisnickoIme=entity.KorisnickoIme,
        ////        Email=entity.Email,
        ////        Telefon=entity.Telefon
        ////    };
        ////}

        public IList<KorisniciDto> GetAll(KorisniciSearchObject search = null)
        {
            var query = Context.Set<Korisnici>().AsQueryable();
            if(!string.IsNullOrWhiteSpace(search?.Ime) || !string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Ime.Contains(search.Ime) || x.Prezime.Contains(search.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.Contains(search.Email));
            }
           
            if (search.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    query = query.Include(item);
                }
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<KorisniciDto>>(entities);
            return result;
        }

        public KorisniciDto Insert(KorisniciInsertRequestDto request)
        {
            
            var entity = _mapper.Map<Korisnici>(request);

            Context.Add(entity);
            
            if (request.Lozinka != request.LozinkaPotvrdi)
            {
                throw new UserException("Lozinka nije ispravna");
            }

            entity.LozinkaSalt = PasswordEncryptionHelper.GenerateSalt();
            entity.LozinkaHash = PasswordEncryptionHelper.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            Context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                KorisniciUloge korisniciUloge = new KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;

                Context.KorisniciUloges.Add(korisniciUloge);
            }
            Context.SaveChanges();
            return _mapper.Map<KorisniciDto>(entity);
        }

       
        public KorisniciDto GetById(int id)
        {
            var entity = Context.Korisnicis.Find(id);

            return _mapper.Map<KorisniciDto>(entity);
        }

        public KorisniciDto Update(int id, KorisniciInsertRequestDto request)
        {

            var entity = Context.Korisnicis.Find(id);
            _mapper.Map(request, entity);

            Context.SaveChanges();
            return _mapper.Map<KorisniciDto>(entity);
        }
    }
}
