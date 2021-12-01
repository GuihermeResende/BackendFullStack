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
    public class MenuCategoriaController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetCategorias()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.menuCategoria.ToList());
            }

        }

        
        [HttpPost]
        public ActionResult CreateCategoria(int Id)
        {
            using (MyContext ctx = new MyContext())
            {
               MenuCategoria menuCategoria = ctx.menuCategoria.Where(u => u.id.Equals(Id)).FirstOrDefault();
                
                if (menuCategoria != null)
                {
                    throw new ArgumentException("Esta categoria já existe");
                }


                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.menuCategoria.Add(menuCategoria);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();

                return Ok(Id);
            }
            //Retornando o usuario inserido já com o ID.
           
        }

        [HttpPut]
        public ActionResult UptadeCategoria(int Id)
        {
            using (MyContext ctx = new MyContext())
            {
                MenuCategoria menuCategoria = ctx.menuCategoria.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if (menuCategoria == null)
                {
                    throw new ArgumentException("Esta categoria não existe");
                }


                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.menuCategoria.Update(menuCategoria);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();

                return Ok(Id);
            }
            //Retornando o usuario inserido já com o ID.

        }


        [HttpDelete]
        public ActionResult DeleteCategoria(int Id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um usuario
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                MenuCategoria menuCategoria = ctx.menuCategoria.Where(u => u.id.Equals(Id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (menuCategoria == null)
                    throw new ArgumentException("Esta categoria não existe");

                //Metodo para remover o usuario
                ctx.menuCategoria.Remove(menuCategoria);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
