﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime DateOfPublish { get; set; }
        public float Price { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
