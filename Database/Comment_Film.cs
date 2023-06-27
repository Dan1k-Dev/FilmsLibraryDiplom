using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица комментариев к фильмам
    /// </summary>
    public class Comment_Film
    {
        [Key]
        public int id { get; set; }
        public int UserID { get; set; }
        public virtual User User_ { get; set; }
        public int FilmID { get; set; }
        public virtual Film Film_ { get; set; }
        public string Comment { get; set; } = null;
    }
}
