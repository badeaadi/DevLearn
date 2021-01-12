using System;
using System.Collections.Generic;
using System.Text;

namespace TestsData
{
    class Item
    {
        public int IdItem { get; set; }
        public string ItemInformation { get; set; }

        public ICollection<string> Variants { get; set; }

        public int RightVariant { get; set; }

    }
}
