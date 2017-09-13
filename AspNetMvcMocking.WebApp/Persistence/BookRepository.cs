using System;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public interface IBookRepository
    {
        Book Get(Int32 id);
        Int32 Create(Book book);
        void Update(Book book);
        void Delete(Int32 id);
    }

    public class BookRepository : IBookRepository
    {
        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}