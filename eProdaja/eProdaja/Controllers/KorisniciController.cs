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
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController:ControllerBase
    {
        private readonly IKorisniciService _korisniciService;
        public KorisniciController(IKorisniciService korisniciService)
        {
            _korisniciService = korisniciService;
        }

        [HttpGet]
        public IList<KorisniciDto> Get()
        {
            return _korisniciService.Get();
        }
        [HttpPost]
        public KorisniciDto Insert([FromBody] KorisniciInsertRequest request)
        {
           return _korisniciService.Insert(request);
        }
    }
}
