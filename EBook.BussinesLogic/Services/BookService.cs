﻿using EBook.Domain;
using EBook.Domain.Entities;
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
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

        }
    }
}
