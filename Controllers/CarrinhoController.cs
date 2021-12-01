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
    public class CarrinhoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Carrinho>> GetItens()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.carrinho.ToList());
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Boolean> DeleteProduct(int Id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                Produto produto = context.produtos.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if (produto == null)
                    return NotFound();


                return true;
            }
        }

        [HttpPut]
        public ActionResult<Carrinho> UpdateCarrinho(int id, Carrinho carrinho)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {

                //Metodo para alterar o registro no Banco de Dados
                ctx.carrinho.Update(carrinho);
                //Confirmar a alteração
                ctx.SaveChanges();
            }

            return carrinho;
        }

    }
}
