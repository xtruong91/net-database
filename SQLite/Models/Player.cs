using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLite.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Tag { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // An ICollection of our enrolments to tournaments :
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
