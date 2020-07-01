using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.DataTransfer
{
    public class QuestionDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<TagIds> TagList { get; set; } = new List<TagIds>();
    }

    public class TagIds
    {
        public int Id { get; set; }
    }
}
