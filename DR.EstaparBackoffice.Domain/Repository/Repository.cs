using DR.EstaparBackoffice.Domain.Data;
using DR.EstaparBackoffice.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DR.EstaparBackoffice.Domain.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DRxEstaparDBContext Db;
        protected readonly List<DRxEstaparDBContext> Dbs = new List<DRxEstaparDBContext>();
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(DRxEstaparDBContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
