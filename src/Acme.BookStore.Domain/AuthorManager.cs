using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository<Author, Guid> _authorRepository;

        public AuthorManager(IAuthorRepository<Author, Guid> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync   
                (Guid id,
                string name,
                DateTime dateOfBirth,
                string? shortBio)
                    
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _authorRepository.FindByNameAsync(name);

            if(existingAuthor is not null)
            {
                throw new AuthorAlreadyExistsException(name);
            }

            return new Author
                    (
                        GuidGenerator.Create(),
                        name,
                        dateOfBirth,
                        shortBio
                    );

        }

        public async Task ChangeNameAsync(Author author, string newName)
        {
            Check.NotNullOrWhiteSpace (newName, nameof(newName));
            Check.NotNull(author, nameof(author));
            
            var existingAuthor = _authorRepository.FindByNameAsync(newName);

            if (existingAuthor is not null or existingAuthor.id != author.Id)
            {
                throw new AuthorAlreadyExistsException(newName);
            }

            author.ChangeName(newName);
        }
    }
}
