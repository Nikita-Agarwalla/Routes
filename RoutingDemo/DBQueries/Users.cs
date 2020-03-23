using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RoutingDemo.Models;
using RoutingDemo.DBContext;

namespace RoutingDemo.DBQueries
{
    public class Users
    {
        private readonly static CompanyDBContext _companyDbContext = new CompanyDBContext();
        public static List<User> FetchAllUser() => _companyDbContext.User.ToList<User>();

        public static User FetchUserByID(int ID) => _companyDbContext.User.Where(user => user.ID == ID).FirstOrDefault();

        public static void AddRole(int ID, int RoleID)
        {
            _companyDbContext.MapUser.Add(new MapUser()
            {
                User = _companyDbContext.User.FirstOrDefault(user => user.ID == ID),
                Role = _companyDbContext.Master_Roles.FirstOrDefault(role => role.ID == RoleID)
            });
            _companyDbContext.SaveChanges();
        }

        public static void DeleteUser(int UserID)
        {
            _companyDbContext.MapUser.RemoveRange(_companyDbContext.MapUser.Where(user => user.User.ID == UserID));
            _companyDbContext.User.Remove(_companyDbContext.User.FirstOrDefault(user => user.ID == UserID));
        }

        public static User LoginUserWithEmailAndPassword(string Email, string Password)
        {
            try
            {
                return _companyDbContext.User.Include(user => user.Role).Single(user => user.EmailID.Equals(Email) && user.Password.Equals(Password));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}