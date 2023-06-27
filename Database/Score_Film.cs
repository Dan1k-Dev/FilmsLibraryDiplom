using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    public class Score_Film
    {
        [Key]
        public int Id { get; set; }
        public double? Score { get; set; }
        public int FilmID { get; set; }
        public virtual Film Film_ { get; set; }
        public int UserID { get; set; }
        public virtual User User_ { get; set; }
        public double? SumScore { get; set; }
        public int? CountScore { get; set; }
    }
}
