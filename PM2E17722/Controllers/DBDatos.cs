using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2E17722.Models;

namespace PM2E17722.Controllers
{
    public class DBDatos
    {
        readonly SQLiteAsyncConnection _connection;
        public DBDatos() { }
        public DBDatos(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<Datos>().Wait();
        }

        //CREATE
        public Task<int> AddDatos(Datos datos)
        {
            if(datos.ID == 0)
            {
                //INSERT
                return _connection.InsertAsync(datos);
            }
            else
            {
                //UPDATE
                return _connection.UpdateAsync(datos);
            }
        } 

        //READ
        public Task<List<Datos>> GetAll()
        {
            return _connection.Table<Datos>().ToListAsync();
        }

        //DELETE
        public Task<int> DeleteDatos(Datos datos)
        {
            return _connection.DeleteAsync(datos);
        }
    }
}
