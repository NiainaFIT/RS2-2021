using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class JediniceMjereService : BaseReadService<JediniceMjereDto,JediniceMjere, object>,IJediniceMjereService
    {
        public JediniceMjereService(eProdajaContext context,IMapper mapper)
            :base(context,mapper)
        {
        }
    }
}
