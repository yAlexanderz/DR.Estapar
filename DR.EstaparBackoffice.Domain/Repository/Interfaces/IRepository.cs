using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Repository.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
