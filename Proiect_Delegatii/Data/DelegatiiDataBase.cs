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
            _database.CreateTableAsync<Filiala>().Wait();
            _database.CreateTableAsync<ListFiliala>().Wait();

        }
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

        public Task<int> SaveFilialaAsync(Filiala filiala)
        {
            if (filiala.ID != 0)
            {
                return _database.UpdateAsync(filiala);
            }
            else
            {
                return _database.InsertAsync(filiala);
            }
        }
        public Task<int> DeleteFilialaAsync(Filiala filiala)
        {
            return _database.DeleteAsync(filiala);
        }
        public Task<List<Filiala>> GetFilialaAsync()
        {
            return _database.Table<Filiala>().ToListAsync();
        }

        public Task<int> SaveListFilialaAsync(ListFiliala lista)
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

        public Task<List<Angajat>> GetListFilialeAsync(int angajatid)
        {
            return _database.QueryAsync<Angajat>(
            "select F.ID, F.Judet, F.Tara from Filiala F"
            + " inner join ListFiliala LF"
            + " on F.ID = LF.FilialaID where LA.AngajatID = ?",
            angajatid);
        }
    }
}

