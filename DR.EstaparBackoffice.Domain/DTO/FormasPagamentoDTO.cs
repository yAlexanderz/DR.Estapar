using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.DTO
{
    public class FormasPagamentoDTO
    {
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
    }
}
