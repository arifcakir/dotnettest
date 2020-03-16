using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SMS.Core.Data;

namespace SMS.DAL.Entities
{
    public  class Student : BaseDataEntity
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StudentId { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
