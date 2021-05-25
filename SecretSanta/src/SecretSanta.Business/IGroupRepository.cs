using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IGroupRepository
    {
        ICollection<Group> List();
        Group? GetItem(int id);
        bool Remove(int id);
        Group Create(Group item);
        AddAssignmentResult AddAssignment(int groupId);
        void Save(Group item);
    }

}
