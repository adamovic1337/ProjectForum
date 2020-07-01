using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Bogus;
using MoreLinq;
using ProjectForum.Application;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.API.Core
{
    public class FakerData : IFakerData
    {
        private readonly ProjectForumContext _context;

        public FakerData(ProjectForumContext context)
        {
            _context = context;
        }

        public void AddCountries()
        {
            var quantity = 50;
            var doubleQuantity = quantity * 2;

            var countriesFaker = new Faker<Country>();

            countriesFaker.RuleFor(country => country.Name, f => f.Address.Country());

            var countries = countriesFaker.Generate(doubleQuantity);

            var uniqueCountries = countries.DistinctBy(c => c.Name)
                                                .ToList()
                                                .GetRange(0, quantity);

            _context.Countries.AddRange(uniqueCountries);
            _context.SaveChanges();
        }
        public void AddRoles()
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "admin"
                },
                new Role
                {
                    Name = "user"
                }
            };

            _context.Roles.AddRange(roles);
            _context.SaveChanges();

        }
        public void AddUsers()
        {
            var quantity = 20;
            var doubleQuantity = quantity * 2;
            var usersFaker = new Faker<User>();

            usersFaker.RuleFor(user => user.FirstName, f => f.Name.FirstName());
            usersFaker.RuleFor(user => user.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(user => user.Username, f => f.Internet.UserName());
            usersFaker.RuleFor(user => user.Email, f => f.Internet.Email());
            usersFaker.RuleFor(user => user.Password, f => f.Internet.Password());

            var countryIds = _context.Countries.Select(country => country.Id).ToList();

            usersFaker.RuleFor(user => user.CountryId, f => f.PickRandom(countryIds));

            var roleIds = _context.Roles.Select(role => role.Id).ToList();

            usersFaker.RuleFor(user => user.RoleId, f => f.PickRandom(roleIds));


            var users = usersFaker.Generate(doubleQuantity);

            while (users.DistinctBy(u => u.Username).ToList().Count < 20 && users.DistinctBy(u => u.Email).ToList().Count < 20)
            {
                users = usersFaker.Generate(doubleQuantity);
            }

            var uniqueUsers = users.DistinctBy(u => u.Username).ToList().GetRange(0, quantity);

            _context.Users.AddRange(uniqueUsers);
            _context.SaveChanges();
        }
        public void AddCategories()
        {
            var quantity = 15;
            var doubleQuantity = quantity * 2;
            var categoriesFaker = new Faker<Category>();

            categoriesFaker.RuleFor(category => category.Name, f => f.Lorem.Word());


            var categories = categoriesFaker.Generate(doubleQuantity);

            var uniqueCategories = categories.DistinctBy(category => category.Name)
                                                    .ToList()
                                                    .GetRange(0, quantity);

            _context.Categories.AddRange(uniqueCategories);
            _context.SaveChanges();

        }
        public void AddQuestions()
        {
            var quantity = 300;
            var questionsFaker = new Faker<Question>();

            questionsFaker.RuleFor(question => question.Title, f => f.Lorem.Sentence());
            questionsFaker.RuleFor(question => question.Body, f => f.Lorem.Text());

            var categoryIds = _context.Categories.Select(category => category.Id).ToList();

            questionsFaker.RuleFor(question => question.CategoryId, f => f.PickRandom(categoryIds));

            var userIds = _context.Users.Select(user => user.Id).ToList();

            questionsFaker.RuleFor(question => question.UserId, f => f.PickRandom(userIds));

            var questions = questionsFaker.Generate(quantity);


            _context.Questions.AddRange(questions);
            _context.SaveChanges();
        }
        public void AddReplies()
        {
            var quantity = 700;
            var repliesFaker = new Faker<Reply>();

            repliesFaker.RuleFor(question => question.Body, f => f.Lorem.Sentences());

            var questionIds = _context.Questions.Select(question => question.Id).ToList();

            repliesFaker.RuleFor(reply => reply.QuestionId, f => f.PickRandom(questionIds));

            var userIds = _context.Users.Select(user => user.Id).ToList();

            repliesFaker.RuleFor(question => question.UserId, f => f.PickRandom(userIds));

            var replies = repliesFaker.Generate(quantity);


            _context.Replies.AddRange(replies);
            _context.SaveChanges();
        }
        public void AddTags()
        {
            var quantity = 10;
            var doubleQuantity = quantity * 2;

            var tagsFaker = new Faker<Tag>();

            tagsFaker.RuleFor(tag => tag.Name, f => f.Lorem.Word());

            var questionsTagsFaker = new Faker<QuestionTag>();
            
            var questionIds = _context.Questions.Select(question => question.Id).ToList();

            questionsTagsFaker.RuleFor(questionTag => questionTag.QuestionId, f => f.PickRandom(questionIds));

            tagsFaker.RuleFor(tag => tag.TagQuestions, f => questionsTagsFaker.Generate(2));

            var tags = tagsFaker.Generate(doubleQuantity);

            var uniqueTags = tags.DistinctBy(tag => tag.Name).ToList().GetRange(0, quantity);

            _context.Tags.AddRange(uniqueTags);
            _context.SaveChanges();
        }
        public void AddUseCases()
        {
            var roleUseCases = new List<RoleUseCase>();


            // Svaki UseCase za admina
            for (int i = 0; i <= 400; i++)
            {
                roleUseCases.Add( new RoleUseCase
                {
                    RoleId = 2,
                    UseCaseId = i
                });
            }

            // UseCase sa ID (300-400) su get svojstva cisto da se ogranici user 
            for (int i = 300; i <= 400; i++) 
            {
                roleUseCases.Add(new RoleUseCase
                {
                    RoleId = 1,
                    UseCaseId = i
                });
            }

            _context.RoleUseCases.AddRange(roleUseCases);
            _context.SaveChanges();
        }
    }

}
