using AutoMapper;
using GymOrganizer.Data.Db;
using GymOrganizer.Data.Model;
using GymOrganizer.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymOrganizer.Web.Services
{
    public class ScheduleService
    {
        private readonly GymOrganizerContext db;

        public ScheduleService(GymOrganizerContext db)
        {
            this.db = db;
        }


        public async Task<List<ScheduleVM>> GetAllSchedules()
        {
            return await this.db.Schedules
                .Include(x => x.User)
                .Select(x => Mapper.Map<ScheduleVM>(x)).ToListAsync();
        }

        public async Task<ScheduleVM> GetScheudleById(Guid scheduleId)
        {
            return await this.db.Schedules
                .Include(x => x.User)
                .Where(x => x.Id == scheduleId)
                .Select(x => Mapper.Map<ScheduleVM>(x))
                .FirstOrDefaultAsync();
        }

        public async Task AddSchedule(ScheduleVM scheduleModel)
        {
            Schedule schedule = Mapper.Map<Schedule>(scheduleModel);
            schedule.User = null;
            this.db.Schedules.Add(schedule);
            await this.db.SaveChangesAsync();
        }

        public async Task EditSchedule(ScheduleVM scheduleModel)
        {
            var oldSchedule = await this.db.Schedules.Where(x => x.Id == scheduleModel.Id).FirstOrDefaultAsync();

            oldSchedule.Date = scheduleModel.Date;
            oldSchedule.Description = scheduleModel.Description;
            oldSchedule.UserId = scheduleModel.User.Id;

            await this.db.SaveChangesAsync();
        }
        public async Task DeleteSchedule(Guid scheduleId)
        {
            var schedule = await this.db.Schedules.Where(x => x.Id == scheduleId).FirstOrDefaultAsync();
            this.db.Remove(schedule);
            await this.db.SaveChangesAsync();
        }
    }
}
