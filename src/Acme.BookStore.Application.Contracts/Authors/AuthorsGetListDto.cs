using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Authors
{
    public class AuthorsGetListDto
    {
        public string Filter {  get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting {  get; set; }

    }
}
