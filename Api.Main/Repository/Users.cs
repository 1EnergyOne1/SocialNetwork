using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Api.Main.Repository
{
    public partial class Users
    {
       SocialhubContext db = new SocialhubContext();
        //public async Task<User?> GetUser(string login, string password, CancellationToken ct)
        //{
        //    try
        //    {
        //        return await db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefaultAsync(ct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<IEnumerable<User>?> GetAllUsers(CancellationToken ct)
        //{
        //    try
        //    {
        //        return await db.Users.ToArrayAsync(ct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<User?> AddUser(User user, CancellationToken ct)
        //{
        //    try
        //    {                
        //        if(user.Isadmin)
        //        {
        //            user.Isadmin = false;
        //        }
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return await db.Users.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefaultAsync(ct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<User?> UpdateUser(User user, CancellationToken ct)
        //{
        //    try
        //    {               
        //        db.Users.Update(user);
        //        db.SaveChanges();
        //       return await db.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync(ct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<bool?> DeleteUser(int id, CancellationToken ct)
        //{
        //    try
        //    {               
        //        var res =  await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync(ct);
        //        db.Users.Remove(res);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
