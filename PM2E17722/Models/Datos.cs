using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E17722.Models
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100)]
        public string latitud { get; set; }

        [MaxLength(100)]
        public string longitud { get; set; }

        [MaxLength(100)]
        public string descripcion { get; set; }

        public byte[] foto { get; set; }
    }
}
