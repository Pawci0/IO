using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using SearchEngine.Model;


namespace SearchEngine
{
    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        IEnumerable<string> Search(string phrase, ESortType sortType, int pageSize);
    }




    
}