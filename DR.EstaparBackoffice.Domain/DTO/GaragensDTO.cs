using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.DTO
{
    public class GaragensDTO
    {
        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public double? Preco1aHora { get; set; }
        public double? PrecoHorasExtra { get; set; }
        public double? PrecoMensalista { get; set; }

    }
}
