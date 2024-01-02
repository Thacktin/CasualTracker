using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasualTracker.Persistence.Models;
using SQLite;

namespace CasualTracker.Persistence
{
    public class CasualTrackerPersistence : ICasualTrackerPersistence
    {
        SQLiteAsyncConnection Database;
        public CasualTrackerPersistence()
        {

        }

        async Task Init()
        {
            if (Database is not null)
            {
                return;
            }
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<User>();
        }
        public async Task<List<Shift>> GetAllShifts()
        {
            await Init();
            return await Database.Table<Shift>().ToListAsync();
        }

        public async Task<User> GetAllUsers()
        {
            await Init();
            return await Database.Table<User>().FirstOrDefaultAsync();
        }

        public List<Workplace> GetAllWorkplaces()
        {
            throw new NotImplementedException();
        }
    }
}
