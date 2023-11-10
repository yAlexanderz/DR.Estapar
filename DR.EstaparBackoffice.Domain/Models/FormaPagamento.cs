using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Models
{
    public class FormaPagamento
    {
        [Key]
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

}
