using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarceloStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        //[Route("clientes")] //Listar todos os clientes
        //[Route("clientes/2587")] //Listar o cliente 2587
        //[Route("clientes/2587/pedidos")] //Listar os pedidos do cliente 2587
        public string Get()
        {
            return "Hello World";
        }
    }
}
