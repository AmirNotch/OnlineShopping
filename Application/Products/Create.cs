using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public List<Log> Logs { get; set; }
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
                var numberOfGood = _context.Logs.Where(x => x.StatusManager == "Ждёт выполнения").FirstOrDefault();
                if (numberOfGood != null)
                {
                    return Unit.Value;
                }

                List<AllLog> allLogs = new List<AllLog>();
                AllLog t1 = null;
                foreach (var log in request.Logs)
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
                
                await _context.Logs.AddRangeAsync(request.Logs);
                await _context.AllLogs.AddRangeAsync(allLogs);

                await _context.SaveChangesAsync();

                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ibrag\RiderProjects\OnlineShopping\Persistence\NumberOfGoods.txt");
                var numberOfGoods = Int32.Parse(lines[lines.Length - 1]);
                
                System.IO.File.AppendAllText(@"C:\Users\ibrag\RiderProjects\OnlineShopping\Persistence\NumberOfGoods.txt", ++numberOfGoods + Environment.NewLine);
                
                return Unit.Value;
            }
        }
    }
}