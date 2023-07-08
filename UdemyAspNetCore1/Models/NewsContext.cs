using System.Collections.Generic;

namespace UdemyAspNetCore1.Models
{
    public static class NewsContext
    {
        public static List<News> List = new()
        {
        new News {Title="haber 1" },
           new News {Title="haber 2" }

        };
    }
}
