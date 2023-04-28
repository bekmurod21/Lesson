using Lesson.Domain.Commons;
using Lesson.Domain.Enums;

namespace Lesson.Domain.Entities
{
    public class User:Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }

    }
}
