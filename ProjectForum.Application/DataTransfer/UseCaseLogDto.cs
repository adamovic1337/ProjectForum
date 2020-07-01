using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.DataTransfer
{
    public class UseCaseLogDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
        public string ActorRole { get; set; }
    }
}
