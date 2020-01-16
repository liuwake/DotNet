using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    /// <summary> 
    /// 此类是对IBookService接口的具体实现，在此类的上面我们声明了[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]标签， 
    /// 此标签代表这个类采用SingleTone（单类模式）来生成对象。 
    /// 使用[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]接口需要导入using System.ServiceModel;命名空间。 
    /// </summary> 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PersonService : IPersonService
    {
        List<Person> _Persons = new List<Person>();
        public void AddPerson(Person person)
        {
            person.Id = Guid.NewGuid().ToString();
            _Persons.Add(person);
        }

        public List<Person> GetAllPersons()
        {
            return _Persons;
        }

        public void RemovePerson(string id)
        {
            Person person = _Persons.Find(p => p.Id == id);

            _Persons.Remove(person);
        }
    }
}