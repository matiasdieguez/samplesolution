using System;

namespace ProjectName.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public short UserType { get; set; }
    }
}
