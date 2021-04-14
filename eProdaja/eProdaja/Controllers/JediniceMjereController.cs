using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    public class JediniceMjereController:BaseReadController<JediniceMjereDto, object>
    {
        public JediniceMjereController(IJediniceMjereService jediniceMjereservice)
            :base(jediniceMjereservice)
        {
        }
       
    }
}
