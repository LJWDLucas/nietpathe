using System;
using System.Collections.Generic;

namespace NietPathe.Models.Movies
{
    public class ViewModelMoviePerformance
    {
            public Movie movie { get; set; }
            public IEnumerable<Performance> performances { get; set; }
    }
}
