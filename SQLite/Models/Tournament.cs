﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLite.Models
{
    public class Tournament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // To generate primary keys manually instead of letting it be generated by our databse
        public int TournamentID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // An ICollection of this tournament's enrolments :
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
