using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Core
{
    public interface IMongoRepository
    {
       Task InsertOneAsync<T>(T insertobj);
    }
}
