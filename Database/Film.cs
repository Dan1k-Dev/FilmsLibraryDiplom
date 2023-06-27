using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Frolov_Cinema.Database
{
    /// <summary>
    /// Таблица фильмов, мультов, аниме
    /// </summary>
    public class Film
    {
        [Key]
        public int id { get; set; }
        public string FilmName { get; set; }
        public int GanreID { get; set; }
        public virtual Ganre_Film Ganre_ { get; set; }
        public string DateStart { get; set; }
        public string Director { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country_ { get; set; }
        public int CategoryID { get; set; }
        public virtual Category_Film Category_ { get; set; }
        public double Rating { get; set; }
        public int AgeLimit { get; set; }
        public int MetrageID { get; set; }
        public virtual Meterage Meterage_ { get; set; }
        public string PhotoPath { get; set; }
        public virtual byte[] Image { get; set; }
        public string Site { get; set; }
    }
}
