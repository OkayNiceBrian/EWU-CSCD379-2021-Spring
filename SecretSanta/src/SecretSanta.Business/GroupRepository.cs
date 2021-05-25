using System;
using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
            return item;
        }

        public Group? GetItem(int id)
        {
            if (MockData.Groups.TryGetValue(id, out Group? user))
            {
                return user;
            }
            return null;
        }

        public ICollection<Group> List()
        {
            return MockData.Groups.Values;
        }

        public bool Remove(int id)
        {
            return MockData.Groups.Remove(id);
        }

        public AddAssignmentResult AddAssignment(int groupId)
        {
            if (!MockData.Groups.ContainsKey(groupId)) {
                return AddAssignmentResult.GroupNotFound();
            }

            Group? group = GetItem(groupId);
            if (group.Equals(null)) {
                return AddAssignmentResult.GroupNotFound();
            }
            
            if(group.Users.Count < 3)
            {
                return AddAssignmentResult.Error("Must have at least 3 Users in group.");
            }

            if (group.Assignments.Count > 0) 
            {
                group.Assignments.Clear();
            }

            List<User> users = new List<User>(group.Users);
            System.Random random = new System.Random();

            for (int i = 0; i < group.Users.Count; i++) 
            {
                User rUser = users[random.Next(users.Count)];
                while (rUser.Id == group.Users[i].Id) 
                {
                    rUser = users[random.Next(users.Count)];
                }
                users.Remove(rUser);
                group.Assignments.Add(new Assignment(group.Users[i], rUser));
            }

            return AddAssignmentResult.Success();
        }

        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
        }
    }

    public class AddAssignmentResult
    {
        public bool IsSuccess => string.IsNullOrWhiteSpace(ErrorMessage);
        public string? ErrorMessage { get; }

        private AddAssignmentResult(string? errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static AddAssignmentResult UserNotFound()
            => new AddAssignmentResult("User not found");
        public static AddAssignmentResult Error(string? eMessage)
            => new AddAssignmentResult(eMessage);

        public static AddAssignmentResult GroupNotFound()
            => new AddAssignmentResult("Group not found");
        
        public static AddAssignmentResult Success()
            => new AddAssignmentResult(null);
    }
}
