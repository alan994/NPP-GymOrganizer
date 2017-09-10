using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymOrganizer.Web.ViewModels
{
    public class ScheduleVM
    {
        public Guid Id { get; set; }        
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public UserVM User { get; set; }
    }
}
