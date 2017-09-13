using System;
using AspNetMvcMocking.WebApp.Models;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.SampleCommand
{
    public interface ICreateOrUpdateBookCommand
    {
        Int32 Execute(BookModel bookModel);
    }

    public class CreateOrUpdateBookCommand : ICreateOrUpdateBookCommand
    {
        private readonly IBookRepository bookRepository;

        public CreateOrUpdateBookCommand(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Int32 Execute(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException("bookModel");
            }
            var book = new Book
                {
                    Id = bookModel.Id,
                    Title = bookModel.Title,
                    AuthorName = bookModel.AuthorName
                };
            if (bookModel.Id > 0)
            {
                bookRepository.Update(book);
                return bookModel.Id;
            }
            return bookRepository.Create(book);
        }
    }
}