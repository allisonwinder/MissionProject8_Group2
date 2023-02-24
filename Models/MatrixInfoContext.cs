using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group2.Models
{
    public class MatrixInfoContext : DbContext
    {
        //Constructor
        public MatrixInfoContext (DbContextOptions <MatrixInfoContext> options) :base(options)
        {

        }

        public DbSet<MatrixResponse> responses { get; set; }

    }
}
