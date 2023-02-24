using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group2.Models
{
    public class MatrixResponse
    {
        [Key]
        [Required]
        public int MatrixId { get; set; }

        public string Task { get; set; }

        public string DueDate { get; set; }

        public int Quadrant { get; set; }

        public string Category { get; set; }

        public bool Completed { get; set; }

    }
}
