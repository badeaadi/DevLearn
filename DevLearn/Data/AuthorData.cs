using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLearn.Data
{
    public class AuthorData
    {
        public int IdAuthor { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<LectureData> Lectures { get; set; }
    }
}
