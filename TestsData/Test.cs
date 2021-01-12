using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestsData
{
    public class Test
    {

        public Author Author { get; set; }

        [ForeignKey("ItemId")]
        public ICollection<Item> Items { get; set; }
    }
}
