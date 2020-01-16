using System.Runtime.Serialization;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Name;

        [DataMember]
        public int Age;
    }
}