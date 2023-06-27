using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица уровня доступа пользователей
    /// </summary>
    public class Access
    {
        [Key]
        public int id { get; set; }
        public string KeyAccess { get; set; }
    }
}
