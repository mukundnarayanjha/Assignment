using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Implementation
{
    public class LogEntryServices : ILogEntryServices
    {
        private readonly AssignmentDBContext _context;
        public LogEntryServices(AssignmentDBContext context)
        {
            _context = context;
        }

        public async Task Add(LogEntry model)
        {
            await _context.LogEntries.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
