using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Authors;

namespace Acme.BookStore
{
    public interface IAuthorAppService
    {
        Task<AuthorsDto> GetAsync(Guid id);
        
        Task<AuthorsDto> UpdateAsync(Guid id, AuthorUpdateDto input);
        
        Task CreateAsync(AuthorCreateDto input);
        
        Task DeleteAsync(Guid id);
         
        Task<List<AuthorsDto>> GelListAsync(AuthorsGetListDto input);
    }
}
