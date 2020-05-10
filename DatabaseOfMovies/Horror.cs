using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    public class Horror : Movie
    {
        //child class of Movie; gets the title and passes the category of horror
        public Horror(string title) : base(title, "horror")
        {

        }
    }
}
