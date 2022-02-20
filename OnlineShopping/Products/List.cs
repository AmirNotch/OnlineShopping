using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DbContext;
using OnlineShopping.Models;

namespace OnlineShopping.Products
{
    public class List
    {
        public class Query : IRequest<List<Product>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Products.ToListAsync();
            }
        }
    }
}