using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Client
{
    public class OperationsFileFeeder
    {
        private readonly IConfiguration _configuration;

        public OperationsFileFeeder(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<IEnumerable<string>> GetContentsAsync()
        {
            string _filePath = _configuration.GetSection("AppSettings:OperationFeed:FilePath").Value;
            return await File.ReadAllLinesAsync(_filePath);
        }
    }
}
