using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Core
{
    public class SortParameters : List<SortParameter>
    {
        public SortParameters()
        {

        }

        public SortParameters(string field, SortDirection direction)
        {
            if (string.IsNullOrEmpty(field))
                throw new ArgumentNullException("field");

            this.Add(new SortParameter() { Direction = direction, Field = field });
        }
    }

    public class SortParameter
    {
        public string Field { get; set; }

        public SortDirection Direction { get; set; }
    }

    public enum SortDirection
    {
        ASC,
        DESC
    }
}
