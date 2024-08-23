using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
public class RabbitMQConfiguration
{
    public int Port { get; set; }
    public string? Exchange { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ExchangeType { get; set; }
    public string? RouteKey { get; set; }
    public List<string> Hostnames { get; set; }

    public RabbitMQConfiguration()
    {
        Hostnames = new List<string>();
    }
}
