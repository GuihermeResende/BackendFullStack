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
    public class MasterUserController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<MasterUser>> GetMaster()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.masterUser.ToList());
            }

        }

        [HttpGet("{id}")]
        public ActionResult<MasterUser> GetPeloId(int Id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                MasterUser masterUser = context.masterUser.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if (masterUser == null)
                    throw new ArgumentException("Este usuário não existe");


                return masterUser;
            }
        }

        [HttpPost]
        public ActionResult<MasterUser> CreateMasterUser(int Id)
        {
            using (MyContext ctx = new MyContext())
            {
                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado

                MasterUser masterUser = ctx.masterUser.Where(u => u.id.Equals(Id)).FirstOrDefault();

                if(masterUser != null)
                throw new ArgumentException("Este usuário master já existe");

                ctx.masterUser.Add(masterUser);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();

                return masterUser;
            }
            
          
        }

        [HttpPut]
        public ActionResult<MasterUser> UpdateUserMaster(int Id)
        {
            using (MyContext ctx = new MyContext())
            { 
                MasterUser masterUser = ctx.masterUser.Where(u => u.id.Equals(Id)).FirstOrDefault();
            if (masterUser != null)
                throw new ArgumentException("Este usuário master já existe");


            //Instanciando um context para interagir com o banco de dados
            
                //Metodo para alterar o registro no Banco de Dados
                ctx.masterUser.Update(masterUser);
                //Confirmar a alteração
                ctx.SaveChanges();

                return masterUser;
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um usuario
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                 MasterUser masterUser = ctx.masterUser.Where(u => u.id.Equals(Id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (masterUser == null)
                    throw new ArgumentException("Usuário não encontrado");

                //Metodo para remover o usuario
                ctx.masterUser.Remove(masterUser);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}

