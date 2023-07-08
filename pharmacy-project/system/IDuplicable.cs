using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.interfaces
{
    public interface IDuplicable<T>
    {
        T Duplicate();
    }
}
