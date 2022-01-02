﻿using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int ID { get; set; }

        public ProductRemoveCommand (int id)
        {
            ID = id;
        }
    }
}
