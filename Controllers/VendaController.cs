using EcommerceTenis.Context;
using EcommerceTenis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceTenis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (MyContext ctx = new MyContext())
            {
                return Ok(ctx.vendas.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                Venda venda = ctx.vendas.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (venda == null)
                    return NotFound();

                return Ok(venda);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                Venda venda = ctx.vendas.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (venda == null)
                    return NotFound();

                ctx.vendas.Remove(venda);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Venda venda)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.vendas.Add(venda);
                ctx.SaveChanges();
            }
            return Ok(venda);
        }

        [HttpPut]
        public ActionResult Put(Venda venda)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.vendas.Update(venda);
                ctx.SaveChanges();
            }
            return Ok(venda);
        }
    }
}
