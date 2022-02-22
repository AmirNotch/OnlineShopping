using System.Collections.Generic;
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

                List<AllLog> allLogs = new List<AllLog>();
                AllLog t1 = null;
                foreach (var log in numberOfGood)
                {
                    t1 = new AllLog();
                    t1.Id = log.Id;
                    t1.Address = log.Address;
                    t1.Cost = log.Cost;
                    t1.Count = log.Count;
                    t1.Payed = log.Payed;
                    t1.Photo = log.Photo;
                    t1.NumberOfGood = log.NumberOfGood;
                    t1.StatusManager = log.StatusManager;
                    t1.Title = log.Title;
                    t1.CardNumber = log.CardNumber;
                    allLogs.Add(t1);
                }
                
                await _context.AllLogs.AddRangeAsync(allLogs);
                
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}