using Acme.BookStore.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public  class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime DateOfPublish { get; set; }
        public float Price { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Comment> comments { get; set; }

    }
}
