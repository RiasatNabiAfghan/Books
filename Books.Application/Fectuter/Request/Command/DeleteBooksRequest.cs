﻿using Books.Application.DTO.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Fectuter.Request.Command
{
    public class DeleteBooksRequest:IRequest<int>
    {
      public BookDTO BookDTO { get; set; }  
    }
}
