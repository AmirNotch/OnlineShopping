using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class ListOfStories
    {
        public class Query : IRequest<List<AllLog>>
        {

        }

        public class Handler : IRequestHandler<Query, List<AllLog>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<AllLog>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.AllLogs.ToListAsync();
            }
        }
    }
}