using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1P
{
    public class Library
    {
        private string _name;
        private List<AbstractLib> _resources;

        public Library(string name)
        {
            _name = name;
            _resources = new List<AbstractLib>();
        }
        public bool HasResource(string name)
        {
            foreach (AbstractLib resource in _resources)
            {
                if (resource.Name == name & resource.OnLoan == false)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddResource(AbstractLib resource)
        {
            _resources.Add(resource);
        }


    }
}
