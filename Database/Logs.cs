using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    public class Logs
    {
        [Key]
        public int id { get; set; }
        public string Datee { get; set; }
        public int idUser { get; set; }
        public virtual User  User { get; set; }
    }
}
