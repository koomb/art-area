using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtArea.Web.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDb _database;
        public UserRepository(ApplicationDb database) => _database = database;

        #region Synchronous
        public void CreateUser(User user)
            => _database.Users.InsertOne(user);

        public void DeleteUser(string name)
            => _database.Users.DeleteOne(x => x.Username == name);

        public User ReadUser(string name)
            => _database.Users.Find(x => x.Username == name).FirstOrDefault();

        public IEnumerable<User> ReadUsers()
            => _database.Users.Find(x => true).ToList();

        public void UpdateUser(User user)
            => _database.Users.ReplaceOne(new BsonDocument("_id", user.Username), user);

        public IQueryable<ArtArea.Models.User> Filter<User>(Expression<Func<ArtArea.Models.User, bool>> predicate)
        {
            var mongoQuery = _database.Users.AsQueryable();
            var linqQuery = mongoQuery.AsQueryable();

            return linqQuery.Where(predicate);
        }

        #endregion

        #region Asynchronous
        public async Task CreateUserAsync(User user)
            => await _database.Users.InsertOneAsync(user);


        public Task DeleteUserAsync(string username)
            => _database.Users.DeleteOneAsync(x => x.Username == username);


        public Task<User> ReadUserAsync(string username)
            => _database.Users.Find(x => x.Username == username).FirstOrDefaultAsync();


        public Task<IEnumerable<User>> ReadUsersAsync()
            => Task.Run(() => _database.Users.Find(x => true).ToEnumerable());

        // TODO check if mongo will store Username property which is marked
        // as BsonId as `username` or as '_id'
        public Task UpdateUserAsync(User user)
            => _database.Users.ReplaceOneAsync(new BsonDocument("_id", user.Username), user);
        #endregion
    }
}