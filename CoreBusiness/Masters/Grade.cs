using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBusiness.Masters
{
    public class Grade
    {
        public int GradeId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Code")]
        public string Code { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Year")]
        [Range(1900, 2200, ErrorMessage = "Please enter valid Year.")]
        [Column]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please Select Month")]
        [Range(1, 13, ErrorMessage = "Please enter Valid Month.")]
        [Column]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please Check IsUnion")]
        public bool IsUnion { get; set; }

        [Required(ErrorMessage = "Please enter Increment Month")]
        [Range(1, 13, ErrorMessage = "Please enter Valid Month.")]
        [Column]
        public int IncrementMonth { get; set; }
        public string PayHeadIds { get; set; }
    }
}
