using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederCotributor 
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        public BookStoreDataSeederCotributor(IRepository<Book, Guid> bookRepository,
                                            IAuthorRepository authorRepository,
                                            AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                var rGrin = await _authorRepository.InsertAsync
                    (
                        await _authorManager.CreateAsync
                        (
                            "Robert Grin",
                            new DateTime(1940, 01, 03),
                            "He was famous"
                        )
                    );

                var gB = await _authorRepository.InsertAsync
                    (
                        await _authorManager.CreateAsync
                        (
                            "Gurbanguly Berdimuhamedow",
                            new DateTime(1957, 06,29),
                            "He is very good writer"
                        )
                    );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The 48 Laws of Power",
                        AuthorId = rGrin.Id,
                        Type = BookType.Science,
                        DateOfPublish = new DateTime(2000, 09, 01),
                        Price = 200f
                    });


                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "Payhas casmaesi",
                        AuthorId = gB.Id,
                        Type = BookType.Undefined,
                        DateOfPublish = new DateTime(2012, 01, 01),
                        Price = 150f
                    });


                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "Turmenistanyn dermanlyk osumlikleri",
                        AuthorId = gB.Id,
                        Type = BookType.Science,
                        DateOfPublish = new DateTime(2015, 04, 01),
                        Price = 150f
                    });
            }
        }
    }
}
