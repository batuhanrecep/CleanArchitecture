using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;
public class Filter
{
    public string Field { get; set; }
    public string? Value { get; set; }
    public string Operator { get; set; }
    public string? Logic { get; set; }


    public IEnumerable<Filter> Filters { get; set; }

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field, string @operator) //There is an operator type int C#, to not get that we are adding @ 
    {
        Field = field;
        Operator = @operator;
    }
}
