using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;
public class DynamicQuery
{
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }

    public DynamicQuery()
    {
        
    }

    public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
    {
        Sort = sort;
        Filter = filter;
    }
}

//System.Linq.Dynamic library will transform these

//Select * from cars where unitPrice<100 and (transmission = "automatic" or ...)...

//p=>p.UnitPrice<=100 && ()