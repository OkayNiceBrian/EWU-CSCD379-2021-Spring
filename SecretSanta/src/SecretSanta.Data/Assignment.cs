using System;
using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int Id { get; set; }
        public User Giver { get; private set; }
        public User Receiver { get; private set; }
        public Group group { get; set; }

        public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));
        }
    }
}
