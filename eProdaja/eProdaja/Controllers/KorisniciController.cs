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
    [Route("api/[controller]")]
    public class KorisniciController : ControllerBase
    {
        private IKorisniciService _korisniciService;
        public KorisniciController(IKorisniciService korisniciService)
        {
            _korisniciService = korisniciService;
        }
        [HttpGet]
        public IList<KorisniciDto> GetAll([FromQuery] KorisniciSearchObject request)
        {
            return _korisniciService.GetAll(request);
        }
        //[HttpGet("{id}")]
        //public KorisniciDto Get(int id)
        //{
        //    return _korisniciService.GetById(id);
        //}
    }
}
