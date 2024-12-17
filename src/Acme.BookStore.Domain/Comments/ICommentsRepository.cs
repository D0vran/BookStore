using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Comments
{
    public interface ICommentsRepository : IRepository<Comment, Guid>
    {
        Task<List<Comment>> GetListAsync();
    }
}
