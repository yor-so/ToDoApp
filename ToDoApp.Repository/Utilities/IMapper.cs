using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Repository.Utilities
{
    public interface IMapper<TDestiny, TSource>
    {
        TDestiny MapToType(TSource entity);
    }
}
