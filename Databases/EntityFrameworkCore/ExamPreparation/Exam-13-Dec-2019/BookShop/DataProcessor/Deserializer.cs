namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(BookImportDto[]), new XmlRootAttribute("Books"));

            BookImportDto[] booksDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                booksDtos = (BookImportDto[])serializer.Deserialize(reader);

                List<Book> validBooks = new List<Book>();

                foreach (var dto in booksDtos)
                {
                    if (!IsValid(dto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime publishedOn;
                    bool isParsed = DateTime.TryParseExact(dto.PublishedOn, "MM/dd/yyyy", 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                    if (!isParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Book book = new Book()
                    {
                        Name = dto.Name,
                        Genre = (Genre)dto.Genre,
                        Price = dto.Price,
                        Pages = dto.Pages,
                        PublishedOn = publishedOn
                    };

                    validBooks.Add(book);
                    sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }

                context.Books.AddRange(validBooks);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            AuthorImportDto[] authorDtos =
                JsonConvert.DeserializeObject<AuthorImportDto[]>(jsonString);

            List<Author> authors = new List<Author>();

            foreach (var dto in authorDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == dto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Email = dto.Email
                };

                foreach (var bookDto in dto.Books)
                {
                    if (!bookDto.Id.HasValue)
                    {
                        continue;
                    }

                    Book book = context.Books
                        .FirstOrDefault(b => b.Id == bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    AuthorBook authorBook = new AuthorBook()
                    {
                        Author = author,
                        Book = book
                    };

                    author.AuthorsBooks.Add(authorBook);
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, 
                    author.FirstName + ' ' + author.LastName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}