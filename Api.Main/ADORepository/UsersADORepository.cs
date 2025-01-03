using Api.Data;
using NodaTime;
using Npgsql;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Api.Main.ADORepository
{
    public class UsersADORepository
    {

        public async Task<User?> GetUserAsync(string login, string password, CancellationToken ct)
        {
            User user = new User();
            user.Login = "Ответ от сервера";
            user.Password = "Положительный";
            return user;

            //List<User> users = new List<User>();            
            //string _connectionString = "Host=localhost;Username=postgres;Password=Veo48764511;Database=socialhub";

            ////Создание подключения
            //await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            //try
            //{
            //    //Открытие подключения
            //    await connection.OpenAsync();
            //    Console.WriteLine("Подключение открыто");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //var select = ($"SELECT * FROM users");
            
            //await using (var cmd = new NpgsqlCommand(select, connection))
            //    try
            //    {
            //        await using (var reader = await cmd.ExecuteReaderAsync())
            //        {
            //            if (reader.HasRows) // если есть данные
            //            {                            
            //                while (await reader.ReadAsync()) // построчно считываем данные
            //                {
            //                    User user = new User();

            //                    object one = reader.GetValue(0);
            //                    object two = reader.GetValue(1);
            //                    object three = reader.GetValue(2);
            //                    object four = reader.GetValue(3);
            //                    object five = reader.GetValue(4);
            //                    object six = reader.GetValue(5);
            //                    object seven = reader.GetValue(6);
            //                    object eight = reader.GetValue(7);

            //                    if(one.ToString() != "")
            //                        user.Id = Convert.ToInt32(reader.GetValue(0));
            //                    if (two.ToString() != "")
            //                        user.Name = reader.GetValue(1).ToString();
            //                    if (three.ToString() != "")
            //                        user.Lastname = reader.GetValue(2).ToString();
            //                    if (four.ToString() != "")
            //                        user.Login = reader.GetValue(3).ToString();
            //                    if (five.ToString() != "")
            //                        user.Password = reader.GetValue(4).ToString();
            //                    if (six.ToString() != "")
            //                        user.Age = Convert.ToInt32(reader.GetValue(5));
            //                    if (seven.ToString() != "")
            //                    {
            //                        user.Datecreate = Convert.ToDateTime(reader.GetValue(6));
            //                    }
            //                    if (eight.ToString() != "")
            //                        user.Isadmin = Convert.ToBoolean(reader.GetValue(7));
            //                    users.Add(user);
            //                }
            //            }
            //            await reader.CloseAsync();
            //        }
            //        await connection.CloseAsync();
            //        var res = users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            //        if (res != null)
            //            return res;
            //        else return null;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        return null;
            //    }
        }

        public async Task<IEnumerable<User>?> GetAllUsersAsync()
        {
            List<User> users = new List<User>();
            string _connectionString = "Host=localhost;Username=postgres;Password=Veo48764511;Database=socialhub";

            //Создание подключения
            await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            try
            {
                //Открытие подключения
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var select = ($"SELECT * FROM users");

            await using (var cmd = new NpgsqlCommand(select, connection))
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (await reader.ReadAsync()) // построчно считываем данные
                            {
                                User user = new User();

                                object one = reader.GetValue(0);
                                object two = reader.GetValue(1);
                                object three = reader.GetValue(2);
                                object four = reader.GetValue(3);
                                object five = reader.GetValue(4);
                                object six = reader.GetValue(5);
                                object seven = reader.GetValue(6);
                                object eight = reader.GetValue(7);

                                if (one.ToString() != "")
                                    user.Id = Convert.ToInt32(reader.GetValue(0));
                                if (two.ToString() != "")
                                    user.Name = reader.GetValue(1).ToString();
                                if (three.ToString() != "")
                                    user.Lastname = reader.GetValue(2).ToString();
                                if (four.ToString() != "")
                                    user.Login = reader.GetValue(3).ToString();
                                if (five.ToString() != "")
                                    user.Password = reader.GetValue(4).ToString();
                                if (six.ToString() != "")
                                    user.Age = Convert.ToInt32(reader.GetValue(5));
                                if (seven.ToString() != "")
                                {
                                    user.Datecreate = Convert.ToDateTime(reader.GetValue(6));
                                }
                                if (eight.ToString() != "")
                                    user.Isadmin = Convert.ToBoolean(reader.GetValue(7));
                                users.Add(user);
                            }
                        }
                        await reader.CloseAsync();
                    }
                    await connection.CloseAsync();
                    if(users != null)
                        return (IEnumerable<User>?)users;
                    else
                        return null;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
        }
    }
}
