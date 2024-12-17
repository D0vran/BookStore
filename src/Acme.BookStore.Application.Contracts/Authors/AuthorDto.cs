using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorDto : EntityDto
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string? ShortBio { get; set; }
    }
}
