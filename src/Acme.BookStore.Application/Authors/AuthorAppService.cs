using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
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
        public async Task CreateAsync(AuthorCreateDto input)
        {
            await _authorManager.CreateAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<AuthorsDto>> GelListAsync(AuthorsGetListDto input)
        {
            var skipCount = input.SkipCount;
            var maxResult = input.MaxResultCount;
            var filter = input.Filter;
            var sorting =input.Sorting;
            await _authorRepository.GetListAsync(skipCount, maxResult, sorting, filter);
        }

        public async Task<AuthorsDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorsDto>(author);
        }

        [Authorize]
        public Task<AuthorsDto> UpdateAsync(Guid id, AuthorUpdateDto input)
        {
            throw new NotImplementedException();
        }
    }
}
