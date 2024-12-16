using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorUpdateDto : AuditedEntityDto
    {
        [Required]
        [MaxLength(AuthorConst.MaxLength)]
        public string Name { get; private set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string? ShortBio { get; set; }
    }
}
