using BooksApi.Data.Models;
using BooksApi.Entities.Entities;


namespace BooksApi.Services.Services.Interface
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAll();
        Book? GetBookById(int id);
        Task InsertBook(BookDetails bookDetails);
        BookDetails GetBookDetailsById(int id);
    }
}
