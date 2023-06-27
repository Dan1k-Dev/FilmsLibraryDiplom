using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица пользователей
    /// </summary>
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FCs { get; set; }
        public string Email { get; set; } = null;
        public int AccessID { get; set; }
        public virtual Access Access_ { get; set; }
        public string DateB { get; set; }
    }
}
