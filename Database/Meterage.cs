using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица метражей фильмов
    /// </summary>
    public class Meterage
    {
        [Key]
        public int id { get; set; }
        public string MeterageTitle { get; set; }
    }
}
