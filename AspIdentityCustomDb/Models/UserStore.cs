using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AspIdentityCustomDb.Models
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserLockoutStore<User, string>
        , IUserEmailStore<User>, IUserTwoFactorStore<User,string>
    {

        private readonly CustomDbContext db;
        public UserStore()
        {
            this.db = new CustomDbContext();
        }

        public void Dispose()
        {
            //this.db.Dispose();
        }

        public Task CreateAsync(User user)
        {
            if (user == null) { throw new ArgumentNullException("user is null"); }

            this.db.Users.Add(user);
            var result = this.db.SaveChangesAsync();

            return Task.FromResult(result);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            User user = this.db.Users.Find(string.IsNullOrEmpty(userId) ? string.Empty : userId);
            if (user != null)
            {
                return Task.FromResult<User>(user);
            }
            return Task.FromResult<User>(null);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName is null or empty.");
            }

            User user = this.db.Users.Where(x => x.UserName == userName).FirstOrDefault();

            if (user != null)
            {
                return Task.FromResult<User>(user);
            }
            return Task.FromResult<User>(null);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }



        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user != null)
            {
                return Task.FromResult<string>(user.PasswordHash);
            }
            return Task.FromResult<string>(null);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            bool hasPassword = false;
            if (user != null)
            {
                hasPassword = !string.IsNullOrEmpty(this.db.Users.Where(x => x.Id == user.Id).Select(x => x.PasswordHash).FirstOrDefault());
            }

            return Task.FromResult<bool>(hasPassword);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user != null)
            {
                user.PasswordHash = passwordHash;
            }
            return Task.FromResult<object>(null);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult<int>(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }




        public Task<User> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("userName is null or empty.");
            }

            User user = this.db.Users.Where(x => x.UserName == email).FirstOrDefault();

            if (user != null)
            {
                return Task.FromResult<User>(user);
            }
            return Task.FromResult<User>(null);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult<string>(user.UserName);

        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}