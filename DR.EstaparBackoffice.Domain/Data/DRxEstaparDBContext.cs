using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using DR.EstaparBackoffice.Domain.Models;

namespace DR.EstaparBackoffice.Domain.Data
{
    public class DRxEstaparDBContext : DbContext
    {
        public DRxEstaparDBContext(DbContextOptions<DRxEstaparDBContext> options) : base(options)
        {}
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Garagem> Garagens { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }

}
