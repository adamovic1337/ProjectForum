using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface IQuery<in TSearch, out TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}
