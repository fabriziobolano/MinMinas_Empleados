using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaMME.Models;

    public class DefaultConnection : DbContext
    {
        public DefaultConnection (DbContextOptions<DefaultConnection> options)
            : base(options)
        {
        }

        public DbSet<PruebaMME.Models.Negempleado> Negempleado { get; set; } = default!;

public DbSet<PruebaMME.Models.Negoficina> Negoficina { get; set; } = default!;

public DbSet<PruebaMME.Models.NegtipoDocumento> NegtipoDocumento { get; set; } = default!;
    }
