using System;
using System.Collections.Generic;
using System.Text;

namespace TEST5
{
   public class Classes
    {
        public class Ranked
        {
            public object avg { get; set; }
            public int err { get; set; }
            public bool warn { get; set; }
            public object summary { get; set; }
            public IList<object> tierData { get; set; }
            public object timestamp { get; set; }
            public IList<object> historical { get; set; }
            public IList<object> historicalTierData { get; set; }
        }

        public class Normal
        {
            public object avg { get; set; }
            public int err { get; set; }
            public bool warn { get; set; }
            public object timestamp { get; set; }
            public IList<object> historical { get; set; }
        }

        public class ARAM
        {
            public object avg { get; set; }
            public int err { get; set; }
            public bool warn { get; set; }
            public object timestamp { get; set; }
            public IList<object> historical { get; set; }
        }

        public class Example
        {
            public Ranked ranked { get; set; }
            public Normal normal { get; set; }
            public ARAM ARAM { get; set; }
            public override string ToString()
            {
                if (ranked.avg == null)
                {
                    ranked.avg = "Brak danych";
                }
                if (normal.avg == null)
                {
                    normal.avg = "Brak danych";
                }
                if (ARAM.avg == null)
                {
                    ARAM.avg = "Brak danych";
                }
                return $"Ranked MMR: {ranked.avg} \nNormal MMR: {normal.avg} \nAram MMR: {ARAM.avg}";
            }
        }
    }
}
