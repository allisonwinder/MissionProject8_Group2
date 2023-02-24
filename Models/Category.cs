using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group2.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CatergoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
