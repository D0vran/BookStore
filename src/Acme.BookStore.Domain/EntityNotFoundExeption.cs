using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp;

namespace Acme.BookStore
{
    public class EntityNotFoundExeption : BusinessException
    {
        public EntityNotFoundExeption(Type Book, Guid id)
            : base(BookStoreEntityErrorCodes.EntityNotFound)
        {
            WithData(nameof(id), Book);
        }
    }
}
