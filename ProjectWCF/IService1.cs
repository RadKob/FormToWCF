using System.Collections.Generic;
using System.ServiceModel;

namespace ProjectWCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int InsertPersonToDB(Person person);

        [OperationContract]
        int UpdatePersonToDB(Person person);

        [OperationContract]
        int DeletePersonToDB(Person person);

        [OperationContract]
        Person SelectPersonToDB(Person person);

        [OperationContract]
        List<Person> SelectAllPersonToDB();
    }
}
