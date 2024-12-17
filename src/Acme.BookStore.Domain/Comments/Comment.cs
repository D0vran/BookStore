using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Comments
{
    public class Comment : AuditedEntity<Guid>
    {
        public string? Text { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
