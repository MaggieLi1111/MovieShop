using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Cast")]
    public class Cast
    {       
        public int Id { get; set; } 

        [MaxLength(128)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string ProfilePath { get; set; }

        public ICollection<MovieCast> CastsOfMovie { get; set; }
    }
}
