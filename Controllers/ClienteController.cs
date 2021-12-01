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
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.clientes.ToList());
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetPeloId(int Id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                Cliente cliente = context.clientes.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if (cliente == null)
                    return NotFound();


                return cliente;
            }
        }

        [HttpPost]
        public ActionResult<Cliente> CreateClient (Cliente clientes)
        {
            using (MyContext ctx = new MyContext())
            {
                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.clientes.Add(clientes);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();
            }
            //Retornando o usuario inserido já com o ID.
            return clientes;
        }

        [HttpPut]
        public ActionResult<Cliente> UpdateClient(Cliente cliente)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //Metodo para alterar o registro no Banco de Dados
                ctx.clientes.Update(cliente);
                //Confirmar a alteração
                ctx.SaveChanges();
            }

            return cliente;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um usuario
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                Cliente cliente = ctx.clientes.Where(u => u.id.Equals(Id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (cliente == null)
                    return NotFound();

                //Metodo para remover o usuario
                ctx.clientes.Remove(cliente);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
