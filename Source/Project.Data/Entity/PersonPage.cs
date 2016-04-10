using System.Collections.Generic;

namespace Project.Data.Entity
{
    public class PersonPage 
    {
        public long Count { get; set; }
        public int Page { get; set; }
        public List<Person> Items { get; set; }

        public PersonPage()
        {
            Items = new List<Person>();
        }
    }
}