using ProjectForum.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.Commands
{
    public interface ICreateRoleCommand : ICommand<RoleDto>
    {
    }
}
