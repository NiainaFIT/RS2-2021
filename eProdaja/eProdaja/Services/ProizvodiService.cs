using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace eProdaja.Services
{
    public class ProizvodiService:BaseCRUDService<ProizvodiDto,Proizvodi, ProizvodiSearchObject,ProizvodiInsertRequestDto, ProizvodiUpdateRequestDto>, IProizvodiService
    {
        public ProizvodiService(eProdajaContext context, IMapper mapper)
            :base(context,mapper)
        {
        }

        public override IEnumerable<ProizvodiDto> Get(ProizvodiSearchObject search = null)
        {
            var entity = Context.Set<Proizvodi>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.Naziv));
            }
            if (search.JedinicaMjereId.HasValue)
            {
                entity = entity.Where(x => x.JedinicaMjereId == search.JedinicaMjereId);
            }
            if (search.VrstaId.HasValue)
            {
                entity = entity.Where(x => x.VrstaId == search.VrstaId);
            }
            if (search.IncludeJedinicaMjere==true)
            {
                entity = entity.Include("JedinicaMjere");
            }
            if (search.IncludeList?.Length>0)
            {
                foreach (var item in search.IncludeList)
                {
                    entity = entity.Include(item);
                }
            }
            var list = entity.ToList();
            return _mapper.Map<List<ProizvodiDto>>(list);
        }
    }
}
