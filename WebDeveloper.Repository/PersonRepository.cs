using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.Repository
{
    public class PersonRepository : BaseRepository<Person>
    {
        public Person GetById(int id)
        {
            using (var db = new WebContextDb())
            {
                return db.Person.FirstOrDefault(p=> p.BusinessEntityID==id);
            }
        }

        public List<Person> GetListBySize(int size)
        {
            using (var db = new WebContextDb())
            {
                return db.Person
                    .OrderByDescending(p => p.ModifiedDate)
                    .Take(size).ToList();
            }
        }
    }
}
