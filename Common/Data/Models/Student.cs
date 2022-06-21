﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Data.Models
{
    [Table("students")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}