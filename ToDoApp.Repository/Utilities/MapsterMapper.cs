using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace ToDoApp.Repository.Utilities
{
    public class MapsterMapper<TDestiny, TSource> : IMapper<TDestiny, TSource>
    {
        public TDestiny MapToType(TSource entity)
        {
            return entity.Adapt<TDestiny>();
        }
    }
}
