using EcommerceTenis.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Context
{
        public class MyContext : DbContext
        {
            //Criando uma propriedade DBSet para usuarios e OrdemServicos
             public DbSet<Cliente> clientes { get; set; }
             public DbSet<Endereco> endereco { get; set; }
             public DbSet<MasterUser> masterUser { get; set; }
             public DbSet<MenuCategoria> menuCategoria { get; set; }
             public DbSet<Produto> produtos { get; set; }
             public DbSet<Carrinho> carrinho { get; set; }
             public DbSet<Venda> vendas { get; set; }



        //Substituindo o codigo do EntityFramework para adicionarmos nossa String de Conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            //Atribuindo a string de conexão
            optionsBuilder.UseSqlServer("data source=45.93.100.120;initial catalog=FS03;persist security info=True;user id=FS03;password=56412;MultipleActiveResultSets=True;App=exeEf;");
            }

            //Substituindo o metodo OnModelCreating padrão (apagado)
           
        }
    }

