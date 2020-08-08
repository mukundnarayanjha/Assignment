using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public interface ILogEntryServices
    {
        Task Add(LogEntry model);
    }
}
