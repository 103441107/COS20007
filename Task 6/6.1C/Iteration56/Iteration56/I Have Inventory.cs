using System;
namespace Swin_Adventure //nguyen gia huy
{
    public interface I_Have_Inventory
    {
        GameObject Locate(string id);
      
        String Name { get; }
    }
}
