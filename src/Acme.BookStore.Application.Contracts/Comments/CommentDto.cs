using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Comments
{
    public class CommentDto : EntityDto<Guid>
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}