using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    class Student
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentAddress { get; set; }
    }
}
