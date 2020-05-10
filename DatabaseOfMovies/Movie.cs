using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    //parent class of the category classes that gets and sets the private properties and includes methods to return those private properties
    public class Movie
    {
        public Movie(string title, string category)
        {
            Title = title;
            Category = category;
        }

        private string Title { get; set; }
        private string Category { get; set; }

        public string ReturnTitle()
        {
            return Title;
        }

        public string ReturnCategory()
        {
            return Category;
        }



    }
}
