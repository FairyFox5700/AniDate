using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;


namespace Account.Dal.Abstract.Repositories
{
    public interface IRepository<TKey> where TKey : class
    {
        Task<int> Create(TKey item);
        Task<TKey> Read(int id);
        Task<int> Update(TKey item);
        Task<int> Delete(int id);
    }
}
