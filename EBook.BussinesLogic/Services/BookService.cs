using EBook.Domain;
using EBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public class BookService : IBookService
    {
        private readonly EBookAppContext _context;
        public BookService(EBookAppContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            //Categorie category = GetCategorie(book.BookCategorie);
            //book.BookCategorie = GetCategorie()
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

        }
        public async Task AddCat(Categorie categorie)
        {
            await _context.Categories.AddAsync(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var data = await _context.Books.ToListAsync();
            return data;
        }

        public Task GetCategorie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetById(int id)
        {
            var productDetails = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            return productDetails;
        }
        public async Task Delete(int id)
        {
            var product = await _context.Books.FindAsync(id);
            if (product != null)
            {
                var existingConnect = _context.Books.Where(m => m.Id == id).ToList();
                _context.Books.RemoveRange(existingConnect);

                _context.Books.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }
        public List<Categorie> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public async Task Update(Book newProduct)
        {
            var product = await _context.Books.FindAsync(newProduct.Id);

            if (product != null)
            {
                product.Id = product.Id;
                product.Name = newProduct.Name;
                product.URL = newProduct.URL;
                product.Descriptions = newProduct.Descriptions;
                product.NrPage = newProduct.NrPage;
                product.Price = newProduct.Price;
                product.DatePublishing = DateTime.Now;
                product.BookCategorie = newProduct.BookCategorie;
                product.AuthorId = newProduct.AuthorId;
                await _context.SaveChangesAsync();
            }

            //remove Product_Menues
            //var existingConnect = _context.Books.Where(m => m.Id == newProduct.Id).ToList();
            //_context.Books.RemoveRange(existingConnect);
            //await _context.SaveChangesAsync();
        }
    }
}
