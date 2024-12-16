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
        public BookStoreDataSeederCotributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The 48 Laws of Power",
                        Type = BookType.Science,
                        DateOfPublish = new DateTime(2000, 09, 01),
                        Price = 200f
                    });


                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "Payhas casmaesi",
                        Type = BookType.Undefined,
                        DateOfPublish = new DateTime(2012, 01, 01),
                        Price = 150f
                    });


                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "Turmenistanyn dermanlyk osumlikleri",
                        Type = BookType.Science,
                        DateOfPublish = new DateTime(2015, 04, 01),
                        Price = 150f
                    });
            }
        }
    }
}
