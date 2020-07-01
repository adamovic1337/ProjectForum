using System;
using System.Collections.Generic;
using System.Text;
using ProjectForum.Application.DataTransfer;

namespace ProjectForum.Application.Queries
{
    public interface IGetUserQuery : IQuery<int, IEnumerable<UserDto>>
    {
    }
}
