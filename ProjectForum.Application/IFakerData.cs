using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface IFakerData
    {
        void AddCountries();
        void AddRoles();
        void AddUsers();
        void AddCategories();
        void AddQuestions();
        void AddReplies();
        void AddTags();
        void AddUseCases();
    }
}
