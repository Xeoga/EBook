﻿using EBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface IPublishingHouse
    {
        Task<IEnumerable<PublishingHouse>> GetAll();
    }
}