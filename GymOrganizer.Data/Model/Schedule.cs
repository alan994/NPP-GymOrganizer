using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymOrganizer.Data.Model
{
    [Table("Schedules")]
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
