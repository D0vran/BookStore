using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Authors
{
    public class AuthorAppService : BookStoreAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public AuthorAppService(IAuthorRepository authorRepository,
                                AuthorManager authorManager)
        {
            _authorManager = authorManager;
            _authorRepository = authorRepository;
        }

        [Authorize]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                                            input.Name,
                                            input.BirthDate,
                                            input.ShortBio
                                            );

            await _authorRepository.InsertAsync( author );

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if(input.Sorting == null)
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

            var totalCount = input.Filter == null 
                ? await _authorRepository.CountAsync() 
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var existing = await _authorRepository.GetAsync(id);
            
            if(existing.Name != input.Name)
            {
                _authorManager.ChangeNameAsync(existing, input.Name);
            }

            existing.BirthDate = input.BirthDate;
            existing.ShortBio = input.ShortBio;
        }
    }
}
