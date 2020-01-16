using System.Collections.Generic;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    /// <summary> 
    /// ServiceContract：服务约定，代表我们所能操作的接口集合，提供功能点。 
    /// 在IPersonService接口上面，我们定义了[ServiceContract]标签，此标签代表此接口及实现此接口的类都是对外发布的Service类， 
    /// 在每个需要对外发布的方法上都加上[OperationContract]标签，以使外部可以访问到此方法。 
    /// [ServiceContract]和[OperationContract]这两个标签需要导入using System.ServiceModel命名空间。 
    /// </summary> 
    [ServiceContract]
    public interface IPersonService
    {
        /// <summary> 
        /// OperationContract 操作约定，定义每个操作的接口点方法。 
        /// </summary> 
        [OperationContract]
        void AddPerson(Person person);

        /// <summary>
        /// 获取所有的实体的方法
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Person> GetAllPersons();

        /// <summary>
        /// 删除某个实体的方法
        /// </summary>
        /// <param name="id">实体id</param>
        [OperationContract]
        void RemovePerson(string id);
    }
}