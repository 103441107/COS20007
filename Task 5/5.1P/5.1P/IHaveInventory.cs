using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration4
{
    interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name { get; }

    }
}
