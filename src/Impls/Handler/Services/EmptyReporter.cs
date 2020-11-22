using System;
using System.Threading.Tasks;
using Handler.Abstract.Interfaces;
using Microsoft.Extensions.Logging;

namespace Handler.Services
{
    public class EmptyReporter : IReporter
    {
        public Task ReportAsync(string path, Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}