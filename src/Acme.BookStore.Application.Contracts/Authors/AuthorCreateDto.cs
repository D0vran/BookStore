using System;
using System.ComponentModel.DataAnnotations;
using Acme.BookStore.Authors;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace Acme.BookStore
{
    public class AuthorCreateDto : AuditedEntityDto
    {
        [Required]
        [MaxLength(AuthorConst.MaxLength)]
        public string Name { get; private set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public string? ShortBio { get; set; }
    }
}