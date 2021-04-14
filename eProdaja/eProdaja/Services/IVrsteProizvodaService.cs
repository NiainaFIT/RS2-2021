using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    //Nasljeđujem IReadService i radim s modelom koji se zove VrsteProizvodaDto
    public interface IVrsteProizvodaService:IReadService<VrsteProizvodaDto,object>
    {
        //IEnumerable<VrsteProizvodaDto> Get();
        //public VrsteProizvodaDto GetById(int id);
    }
}
