using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assign6.Project1.ABBC.Models
{
    public class TaskResponse //this is the name of the model - in his videos its anywhere he uses 'ApplicationResponse'
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public string DueDate { get; set; }

        [Required]
        [Range(Int32.MinValue, 4)]
        public byte Quadrant { get; set; }
        public bool Completed { get; set; }
        public int CategoryId { get; set; } // created another table with Category
        public Category Category { get; set; }


    }
}
