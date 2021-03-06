﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiRH.Models.Helpers;
using WebApiRH.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiRH.Models.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        public UserService(AppDbContext context)
        {
            this.context = context;
        }

        public User Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var user = context.User.Include(p => p.Avatar).FirstOrDefault(x => x.Login == login);

            // check if username exists and password is correct
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Необходим пароль");

            if (Get(u => u.Login == user.Login) != null)
                throw new AppException($"Пользователь с логином {user.Login} уже существует.");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var dt = DateTime.Now;
            user.CreatedAt = dt;
            user.EditedAt = dt;

            context.Add(user);
            context.SaveChanges();

            return user;
        }

        public User Get(Guid Uid)
        {
            try { return context.User.Where(u => u.Uid == Uid).Single(); }
            catch { return null; }
        }

        public User Get(String Email)
        {
            try { return context.User.Include(u => u.Avatar).Where(u => u.Email == Email).Single(); }
            catch { return null; }
        }
        public User Get(Func<User, bool> predicate)
        {
            try { return context.User.Where(predicate).Single(); }
            catch { return null; }
        }
        public void Update(User user, Guid Fk_Home, int Appartment, String Address)
        {
            if (!context.User.Any(x => x.Uid == user.Uid))
            {
                throw new AppException("Пользователь не найден");
            }
            user.Fk_Home = Fk_Home;
            user.Appartament = Appartment;
            user.Address = Address;
            context.Update(user);
            context.SaveChanges();
        }
        public void UpdateAuth(User user, string password = null)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Необходим пароль");
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var dt = DateTime.Now;
            user.EditedAt = dt;

            context.Update(user);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.Remove(new User() { Uid = id });
        }

        public IEnumerable<User> Fetch(Expression<Func<User, bool>> predicate)
        {
            return context.User.Where(predicate).Include(u => u.Home).Include(u => u.Avatar);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}
