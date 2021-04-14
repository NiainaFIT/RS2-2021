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
    public class KorisniciService : BaseCRUDService<KorisniciDto, Korisnici, KorisniciSearchObject, KorisniciInsertRequestDto, KorisniciUpdateRequestDto>, IKorisniciService
    {
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
        public KorisniciService(eProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<KorisniciDto> Get(KorisniciSearchObject search = null)
        {
            var entity = Context.Set<Korisnici>().AsQueryable();
            if(!string.IsNullOrWhiteSpace(search?.Ime) || !string.IsNullOrWhiteSpace(search?.Prezime))
            {
                entity = entity.Where(x => x.Ime.Contains(search.Ime) || x.Prezime.Contains(search.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                entity = entity.Where(x => x.Email.Contains(search.Email));
            }
           
            if (search.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    entity = entity.Include(item);
                }
            }
            var list = entity.ToList();
            return _mapper.Map<List<KorisniciDto>>(list);
        }

        public override KorisniciDto Insert(KorisniciInsertRequestDto request)
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

        public KorisniciDto Update (int id,KorisniciUpdateRequestDto request)
        {
            var entity = Context.Korisnicis.Find(id);
            _mapper.Map(request, entity);

            Context.SaveChanges();
            return _mapper.Map<KorisniciDto>(entity);
        }
    }
}
