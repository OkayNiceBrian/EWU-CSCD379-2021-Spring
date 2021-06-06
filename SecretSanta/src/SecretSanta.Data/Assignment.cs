using System;
using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int Id { get; set; }
        public User Giver { get; }
        public User Receiver { get; }
        public Group group { get; set; }

        public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));
        }
    }
}
