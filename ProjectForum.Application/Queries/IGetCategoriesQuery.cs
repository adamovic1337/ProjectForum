using System;
using System.Collections.Generic;
using System.Text;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Searches;

namespace ProjectForum.Application.Queries
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch, PagedResponse<CategoryDto>>
    {
    }
}
