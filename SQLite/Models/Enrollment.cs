using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLite.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int PlayerID { get; set; }

        public Tournament Tournament { get; set; }
        public Player Player { get; set; }
    }
}
