using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }
        public string MovieId { get; set; } 

        [MaxLength(2048)]
        public string TrailerUrl { get; set; }

        [MaxLength(2048)]
        public string Name { get; set; }


        // since one movie can have multiple trailers, so that one-to-many relationship 
        // we need to specify the Moive using "navigation property"
        public Movie Movie { get; set; }

    }
}
