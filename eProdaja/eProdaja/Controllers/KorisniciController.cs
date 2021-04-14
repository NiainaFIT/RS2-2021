using eProdaja.Database;
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
    public class KorisniciController : BaseCRUDController<KorisniciDto, KorisniciSearchObject, KorisniciInsertRequestDto, KorisniciUpdateRequestDto>
    {
        public KorisniciController(IKorisniciService korisniciService)
            :base(korisniciService)
        {

        }
    }
}
