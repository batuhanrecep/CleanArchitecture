using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Performance;
public interface IIntervalRequest
{
    public int Interval { get; }
}
