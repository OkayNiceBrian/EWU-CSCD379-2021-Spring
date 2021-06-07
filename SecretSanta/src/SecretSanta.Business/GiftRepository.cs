using System;
using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Business
{
    public class GiftRepository : IGiftRepository
    {
        private readonly DbContext DbContext;
        public GiftRepository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public ICollection<Gift> List(int id)
        {
            return DbContext.Gifts.Where(item => item.UserId == id).ToList();
        }

        public async Gift Create(Gift item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            await DbContext.Gifts.AddAsync(item);
            await DbContext.SaveChangesAsync();
            return item;
        }
    }
}