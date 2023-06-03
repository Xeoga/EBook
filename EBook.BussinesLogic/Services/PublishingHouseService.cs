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
    public class PublishingHouseService : IPublishingHouse
    {
        private readonly EBookAppContext _context;
        public PublishingHouseService(EBookAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PublishingHouse>> GetAll()
        {
            var data = await _context.PublishingHouses.ToListAsync();
            return data;
            //throw new NotImplementedException();
        }

    }
}
