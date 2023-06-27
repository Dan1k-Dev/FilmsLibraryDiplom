using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица категорий фильмов
    /// </summary>
    public class Category_Film
    {
        [Key]
        public int id { get; set; }
        public string Category { get; set; }
    }
}
