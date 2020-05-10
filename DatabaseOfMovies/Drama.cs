using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    //child class of Movie; gets the title and passes the category of drama
    public class Drama : Movie
    {
        public Drama(string title) : base(title, "drama")
        {

        }
    }
}
