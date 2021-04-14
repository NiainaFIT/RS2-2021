using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    public class ProizvodiController:BaseCRUDController<ProizvodiDto, ProizvodiSearchObject,ProizvodiInsertRequestDto, ProizvodiUpdateRequestDto>
    {
        public ProizvodiController(IProizvodiService proizvodService)
            :base(proizvodService)
        {
        }
    }
}
