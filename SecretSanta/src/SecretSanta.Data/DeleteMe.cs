using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class DeleteMe
    {
        public static List<User> Users { get; } = new()
        {
            new User() { Id = 1, FirstName = "Vincent", LastName = "Mejia"},
            new User() { Id = 2, FirstName = "Riley", LastName = "Morales"},
            new User() { Id = 3, FirstName = "Sophia", LastName = "Nelson"}
        };
    }
}