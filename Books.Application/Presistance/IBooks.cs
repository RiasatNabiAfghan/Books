﻿using Books.Domain.NormalDomin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Presistance
{
    public interface IBooks:IGenericRepository<BookModel>
    {
    }
}
