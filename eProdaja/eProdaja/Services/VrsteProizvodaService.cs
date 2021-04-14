using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
                                                            //T,Tdb
    public class VrsteProizvodaService : BaseReadService<VrsteProizvodaDto,VrsteProizvodum, object>, IVrsteProizvodaService
    {
        public VrsteProizvodaService(eProdajaContext context, IMapper mapper)
            :base(context,mapper)
        {   
        }
    }
}
