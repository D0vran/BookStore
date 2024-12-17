using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore
{
    public interface IAuthorAppService
    {
        Task<AuthorDto> GetAsync(Guid id);
        
        Task UpdateAsync(Guid id, UpdateAuthorDto input);
        
        Task<AuthorDto> CreateAsync(CreateAuthorDto input);
        
        Task DeleteAsync(Guid id);
         
        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);
    }
}
