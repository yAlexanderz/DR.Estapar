using DR.EstaparBackoffice.Domain.Data;
using DR.EstaparBackoffice.Domain.DTO;
using DR.EstaparBackoffice.Domain.Models;
using DR.EstaparBackoffice.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Repository
{
    public class EstaparRepository : Repository<Object>, IEstaparRepository
    {
        private readonly DRxEstaparDBContext _dbContext;

        public EstaparRepository(DRxEstaparDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Passagem>> DadosPassagens(string? garagem)
        {
            var query = _dbContext.Passagens.AsQueryable();

            if (!string.IsNullOrEmpty(garagem))
            {
                query = query.Where(p => p.Garagem == garagem);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Garagem>> DadosGaragens(string? codigo)
        {
            var query = _dbContext.Garagens.AsQueryable();

            if (!string.IsNullOrEmpty(codigo))
            {
                query = query.Where(g => g.Codigo == codigo);
            }

            return await query.ToListAsync();
        }

        public async Task<List<FormaPagamento>> FormasPagamento(string? sigla)
        {
            var query = _dbContext.FormasPagamento.AsQueryable();

            if (!string.IsNullOrEmpty(sigla))
            {
                query = query.Where(f => f.Codigo == sigla);
            }

            return await query.ToListAsync();
        }
    }
}
