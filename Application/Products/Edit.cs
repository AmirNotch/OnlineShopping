using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Log Log { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var numberOfGood = await _context.Logs.Where(x => x.NumberOfGood == request.Log.NumberOfGood).ToListAsync();

                if (numberOfGood == null)
                {
                    return Unit.Value;
                }
                

                //var AllLogByNumberOfGood = await _context.Logs.Where(x => x.NumberOfGood == numberOfGood.NumberOfGood).ToListAsync();

                foreach (var number in numberOfGood)
                {
                    if (number.StatusManager == "Выполнено")
                    {
                        number.StatusManager = "Ждёт выполнения";
                    }
                    else
                    {
                        number.StatusManager = "Выполнено";
                    }
                }

                //await _context.Logs.AddRangeAsync(numberOfGood);
                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }
    }
}