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
    public class UserService
    {
        private readonly GymOrganizerContext db;

        public UserService(GymOrganizerContext db)
        {
            this.db = db;
        }


        public async Task<List<UserVM>> GetAllUsers()
        {
            return await this.db.Users.Select(x => Mapper.Map<UserVM>(x)).ToListAsync();
        }

        public async Task<UserVM> GetUserById(Guid userId)
        {
            return await this.db.Users
                .Where(x => x.Id == userId)
                .Select(x => Mapper.Map<UserVM>(x))
                .FirstOrDefaultAsync();
        }

        public async Task AddUser(UserVM userModel)
        {
            var user = Mapper.Map<User>(userModel);
            this.db.Users.Add(user);
            await this.db.SaveChangesAsync();
        }

        public async Task EditUser(UserVM userModel)
        {
            var oldUser = await this.db.Users.Where(x => x.Id == userModel.Id).FirstOrDefaultAsync();

            oldUser.FirstName = userModel.FirstName;
            oldUser.LastName = userModel.LastName;
            oldUser.Email = userModel.Email;
            oldUser.PhoneNumber = userModel.PhoneNumber;
            oldUser.Type = (UserType)userModel.Type;

            await this.db.SaveChangesAsync();
        }
        public async Task DeleteUser(Guid userId)
        {
            var user = await this.db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            var userSchedules = await this.db.Schedules.Where(x => x.UserId == userId).ToListAsync();
            if(userSchedules.Any())
            {
                this.db.Schedules.RemoveRange(userSchedules);
            }

            this.db.Remove(user);
            await this.db.SaveChangesAsync();
        }
    }
}
