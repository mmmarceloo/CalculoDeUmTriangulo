using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsultaCep.Models;

namespace ConsultaCep.Data
{
    public class ConsultaCepContext : DbContext
    {
        public ConsultaCepContext (DbContextOptions<ConsultaCepContext> options)
            : base(options)
        {
        }

        public DbSet<ConsultaCep.Models.Cep> Cep { get; set; } = default!;
    }
}
