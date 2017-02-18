using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public interface IAlgorithm
    {
        OutputObject Execute(InputObject inputObject);

        string GetName();
    }
}
