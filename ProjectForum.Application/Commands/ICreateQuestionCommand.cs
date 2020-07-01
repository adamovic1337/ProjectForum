using System;
using System.Collections.Generic;
using System.Text;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;

namespace ProjectForum.Application.Commands
{
    public interface ICreateQuestionCommand : ICommand<QuestionDto>
    {
        void AddQuestionTags(QuestionDto dto, Question question);
    }
}
