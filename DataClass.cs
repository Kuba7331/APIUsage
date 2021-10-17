using System;
using System.Collections.Generic;
using System.Text;

namespace TEST5
{
    public class DataClass
    {
        string name,region;

        public string getName()
        {
            return name;
        }
        public string getRegion()
        {
            return region;
        }
        public void setName(string Name)
        {
            this.name = Name;
        }
        public void setRegion (string Region)
        {
            this.region = Region;
        }
    }
}
