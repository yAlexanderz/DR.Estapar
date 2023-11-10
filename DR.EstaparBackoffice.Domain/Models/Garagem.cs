using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Models
{
    public class Garagem
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco_1aHora { get; set; }
        public decimal Preco_HorasExtra { get; set; }
        public decimal Preco_Mensalista { get; set; }
    }

}
