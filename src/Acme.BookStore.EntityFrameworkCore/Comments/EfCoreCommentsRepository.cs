using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.Comments
{
    internal class EfCoreCommentsRepository 
        : BookStoreDbContext<BookStoreDbContext, Comment, Guid>, 
        ICommentsRepository
    {
        public EfCoreCommentsRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        {
            
        }


    }
}
