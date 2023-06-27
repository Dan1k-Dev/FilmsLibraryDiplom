using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица истории просмотров
    /// </summary>
    public class History
    {
        [Key]
        public int id { get; set; }
        public int FilmID { get; set; }
        public virtual Film Film_ { get; set; }
        public string Date { get; set; }
        public int CountView { get; set; }
        public int idUser { get; set; }
        public virtual User User { get; set; }
    }
}
