﻿using System;
using System.Linq;
using System.Web.Security;
using WebApplicationRandomOrg.Models;
using System.Data.Entity;

namespace WebApplicationRandomOrg.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (WebAppDbContext db = new WebAppDbContext())
            {
                // Получаем пользователя
                UserAccount user = db.UserAccounts.Include(u => u.Role).FirstOrDefault(u => u.Email == username);
                if (user != null && user.Role != null)
                {
                    // получаем роль
                    roles = new string[] { user.Role.RoleName };
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {

           
            using (WebAppDbContext db = new WebAppDbContext())
            {
                UserAccount user = db.UserAccounts.Include(u => u.Role).FirstOrDefault(u => u.Email == username);
                if (user != null && user.Role != null && user.Role.RoleName == roleName)
                    return true;
                else
                    return false;
            }

           
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}