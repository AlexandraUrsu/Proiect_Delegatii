using System;
using System.Collections.Generic;

using SQLite;
using System.Threading.Tasks;
using Proiect_Delegatii.Models;

namespace Proiect_Delegatii.Data
{
    public class DelegatiiDataBase
    {
        readonly SQLiteAsyncConnection _database;
        public DelegatiiDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Delegatie>().Wait();
            _database.CreateTableAsync<Angajat>().Wait();
            _database.CreateTableAsync<ListAngajat>().Wait();
            _database.CreateTableAsync<User>().Wait();

        }

        //Delegatie 

        public Task<List<Delegatie>> GetDelegatieAsync()
        {
            return _database.Table<Delegatie>().ToListAsync();
        }
        
        public Task<Delegatie> GetDelegatieAsync(int id)
        {
            return _database.Table<Delegatie>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
     
        public Task<int> SaveDelegatieAsync(Delegatie slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteDelegatieAsync(Delegatie slist)
        {
            return _database.DeleteAsync(slist);
        }


        //Angajat

        public Task<List<Angajat>> GetAngajatAsync()
        {
            return _database.Table<Angajat>().ToListAsync();
        }

        public Task<int> SaveAngajatAsync(Angajat angajat)
        {
            if (angajat.ID != 0)
            {
                return _database.UpdateAsync(angajat);
            }
            else
            {
                return _database.InsertAsync(angajat);
            }
        }

        public Task<int> DeleteAngajatAsync(Angajat angajat)
        {
            return _database.DeleteAsync(angajat);
        }

        public Task<List<Angajat>> GetAngajatiAsync()
        {
            return _database.Table<Angajat>().ToListAsync();
        }

        //ListAngajat
        public Task<List<Angajat>> GetListAngajatiAsync(int delegatieid)
        {
            return _database.QueryAsync<Angajat>(
            "select A.ID, A.Nume, A.Prenume from Angajat A"
            + " inner join ListAngajat LA"
            + " on A.ID = LA.AngajatID where LA.DelegatieID = ?",
            delegatieid);
        }

        public Task<int> SaveListAngajatAsync(ListAngajat lista)
        {
            if (lista.ID != 0)
            {
                return _database.UpdateAsync(lista);
            }
            else
            {
                return _database.InsertAsync(lista);
            }
        }
        public Task<ListAngajat> GetListAngajatAsync(int delegatieid, int angajatid)
        {
            return _database.FindWithQueryAsync<ListAngajat>(
            "select LA.ID from ListAngajat LA"
            + " where LA.DelegatieID = ? and LA.AngajatID = ?",
            delegatieid, angajatid);
        }

        public Task<int> DeleteListAngajatAsync(ListAngajat listangajat)
        {
            return _database.DeleteAsync(listangajat);
        }

        //User

        public Task<List<User>> GetTotiUseriiAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(String username)
        {
            return _database.Table<User>()
            .Where(i => i.Username == username)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }


        public Task<User> GetParolaAsync(String username)
        {
            return _database.FindWithQueryAsync<User>(
            "select U.Parola from User U"
           + " where U.username = ?",
            username);
        }

        public Task<User> GetRolAsync(String username)
        {
            return _database.FindWithQueryAsync<User>(
            "select U.Rol from User U"
           + " where U.username = ?",
            username);
        }

        //SearchBar
        public Task<List<Delegatie>> GetSearchResults(String text)
        { 
            return _database.QueryAsync<Delegatie>(
            "select D.ID from Delegatie D"
           + " where D.ID = ?",
            text);
        }

        public Task<List<Angajat>> GetSearchAngajatiResults(String text)
        {
            return _database.QueryAsync<Angajat>(
            "select A.ID, A.Nume, A.Prenume from Angajat A"
           + " where A.Nume= ? or A.prenume = ? ",
            text, text, text, text, text, text);
        }

        //DelegatiaAngajatului din ContulMeu
        public Task<List<Delegatie>> GetDelegatiaAngajatuluiAsync(int idangajat)
        {
            return _database.QueryAsync<Delegatie>(
            "select D.ID, D.Locatie, D.Data_Plecare from Delegatii D"
            +"inner join ListAngajat LA"
            +"on D.ID = LA.DelegatieID where LA.AngajatID = ?", idangajat);
        }

        public Task<List<User>> GetUserContulMeuAsync(String username)
        {
            return _database.QueryAsync<User>(
            "select U.ID, U.Username, U.Rol from User U"
           + " where U.Username = ?",
            username);
        }

    }
}

