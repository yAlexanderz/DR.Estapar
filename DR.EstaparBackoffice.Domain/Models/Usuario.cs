using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.EstaparBackoffice.Domain.Models
{
    public class Usuario
    {
        [Key]
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? IdGaragem { get; set; }
    }
}
