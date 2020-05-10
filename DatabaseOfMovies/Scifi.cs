using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    public class Scifi : Movie
    {
        //child class of Movie; gets the title and passes the category of scifi
        public Scifi(string title) : base(title, "scifi")
        {

        }
    }
}
