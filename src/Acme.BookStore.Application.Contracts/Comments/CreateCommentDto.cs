using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Comments
{
    public class CreateCommentDto : AuditedEntityDto<Guid>
    {
        [MaxLength(CommentConsts.maxCommentLength)]
        public string Comment {  get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
