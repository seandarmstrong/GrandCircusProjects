using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    //child class of Movie; gets the title and passes the category of animated
    public class Animated : Movie
    {
        public Animated(string title) : base(title, "animated")
        {

        }
    }
}
