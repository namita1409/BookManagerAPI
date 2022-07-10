using BookManagerApi.Models;

namespace BookManagerApi.Services
{
	public class BookManagementService : IBookManagementService
	{
        private readonly BookContext _context;

        public BookManagementService(BookContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public Book Create(Book book)

        {
            var existingBook = FindBookById(book.Id);
            try
            {
                if (existingBook == null)
                {
                    _context.Add(book);
                    _context.SaveChanges();                    
                    return book;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return book;
        }

        public Book Update(long id, Book book)
        {
            try
            {
                var existingBookFound = FindBookById(id);
                if (existingBookFound != null)
                {

                    existingBookFound.Title = book.Title;
                    existingBookFound.Description = book.Description;
                    existingBookFound.Author = book.Author;
                    existingBookFound.Genre = book.Genre;

                    _context.SaveChanges();
                    return book;
                }
            }
            catch (NullReferenceException e) { 
                Console.WriteLine(e.Message);
            }
            return book;
        }
        public bool Delete(long id)
        {
            //try catch blcok          

            try
            {
                var existingBookFound = FindBookById(id);                
                if (existingBookFound != null)
                {
                    _context.Remove(existingBookFound);
                    _context.SaveChanges();
                    return true;
                 }
            }
            catch (NullReferenceException e) { 
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public Book FindBookById(long id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public bool BookExists(long id)
        {
            return _context.Books.Any(b => b.Id == id);
        }       
    }
}

