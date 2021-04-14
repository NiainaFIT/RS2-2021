using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eProdaja.Services
{
    public interface IKorisniciService:ICRUDService<KorisniciDto,KorisniciSearchObject,KorisniciInsertRequestDto,KorisniciUpdateRequestDto>
    {  
    }
}
