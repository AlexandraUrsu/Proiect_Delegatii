using System;
using System.Collections.Generic;
using System.Text;
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
            
        }
        public Task<List<Delegatie>> GetDelegatieAsync()
        {
            return _database.Table<Delegatie>().ToListAsync();
        }
        public Task<List<Angajat>> GetAngajatAsync()
        {
            return _database.Table<Angajat>().ToListAsync();
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
        public Task<List<Angajat>> GetListAngajatiAsync(int delegatieid)
        {
            return _database.QueryAsync<Angajat>(
            "select A.ID, A.Nume, A.Prenume from Angajat A"
            + " inner join ListAngajat LA"
            + " on A.ID = LA.AngajatID where LA.DelegatieID = ?",
            delegatieid);
        }
    }
}

