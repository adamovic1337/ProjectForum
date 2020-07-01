using System;
using System.Collections.Generic;
using System.Text;
using ProjectForum.Application.DataTransfer;

namespace ProjectForum.Application.Commands
{
    public interface ICreateCountryCommand : ICommand<CountryDto>
    {
    }
}
