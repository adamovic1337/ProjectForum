using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string SearchBy { get; set; }
        public string SearchText { get; set; }

    }
}
