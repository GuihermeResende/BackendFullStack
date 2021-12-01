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
    public class EnderecoController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetEndereco()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.endereco.ToList());
           }

        }

        [HttpGet("{id}")]
        public ActionResult<Endereco> GetEnderecoPeloId(int Id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                Endereco endereco = context.endereco.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if (endereco == null)
                    return NotFound();


                return endereco;
            }
        }

        [HttpPost]
        public ActionResult CreateEndereco(Endereco endereco)
        {
            using (MyContext ctx = new MyContext())
            {
                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.endereco.Add(endereco);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();
            }
            //Retornando o usuario inserido já com o ID.
            return Ok(endereco);
        }

      
        [HttpDelete]
        public ActionResult DeleteEndereco(int Id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um usuario
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                Endereco endereco = ctx.endereco.Where(u => u.id.Equals(Id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (endereco == null)
                    return NotFound();

                //Metodo para remover o usuario
                ctx.endereco.Remove(endereco);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}

