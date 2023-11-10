using DR.EstaparBackoffice.Domain.DTO;
using DR.EstaparBackoffice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Repository.Interfaces
{
    public interface IEstaparRepository
    {
        Task<List<Passagem>> DadosPassagens(string? garagem);
        Task<List<Garagem>> DadosGaragens(string? codigo);
        Task<List<FormaPagamento>> FormasPagamento(string? sigla);
    }
}
