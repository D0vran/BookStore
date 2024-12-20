﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService:
        ICrudAppService<
            BookDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto>
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookUpAsync(Guid id);
    }
}
