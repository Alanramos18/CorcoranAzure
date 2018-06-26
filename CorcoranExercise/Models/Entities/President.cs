using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorcoranExercise.Models.Entities
{
    public class President
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }

        public DateTime? Deathday { get; set; }
        public string Deathplace { get; set; }
    }
}