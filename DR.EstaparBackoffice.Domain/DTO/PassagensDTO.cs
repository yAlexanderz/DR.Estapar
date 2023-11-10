using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.DTO
{
    public class PassagensDTO
    {
        public string? Garagem { get; set; }
        public string? CarroPlaca { get; set; }
        public string? CarroMarca { get; set; }
        public string? CarroModelo { get; set; }
        public DateTime? DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public string? FormaPagamento { get; set; }
        public double? PrecoTotal { get; set; }
    }
}
