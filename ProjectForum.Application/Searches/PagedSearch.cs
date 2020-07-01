﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.Searches
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
