using System.Collections.Generic;
using System.Threading.Tasks;
using GymStore.Model;
using SQLite;

namespace GymStore
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Supplement>().Wait();
        }

        public Task<List<Supplement>> GetPeopleAsync()
        {
            return _database.Table<Supplement>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Supplement person)
        {
            return _database.InsertAsync(person);
        }
    }
}