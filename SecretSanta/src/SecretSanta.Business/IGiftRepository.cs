using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IGiftRepository
    {
        ICollection<Gift> List(int id);
        Gift Create(Gift item);

    }
}