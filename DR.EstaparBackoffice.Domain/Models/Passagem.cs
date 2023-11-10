using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Models
{
    public class Passagem
    {
        [Key]
        public int ID { get; set; }
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public decimal? PrecoTotal { get; set; }
    }

}
