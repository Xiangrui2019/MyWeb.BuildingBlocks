using System;
using System.Threading.Tasks;

namespace Handler.Abstract.Interfaces
{
    public interface IReporter
    {
        Task ReportAsync(string path, Exception exception);
    }
}