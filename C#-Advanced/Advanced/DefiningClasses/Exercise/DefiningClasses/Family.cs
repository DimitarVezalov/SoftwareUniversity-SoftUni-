using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person person = this.People
                .Where(p => p.Age >= this.People.Select(x => x.Age).Max())
                .FirstOrDefault();

            return person;
        }
    }
}
