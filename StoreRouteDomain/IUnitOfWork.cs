using StoreRouteDomain.Entities;
using StoreRouteDomain.RepositoriesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRouteDomain
{
	public interface IUnitOfWork //Design pattern
	{
		Task<int> CompleteAsync();

		//create repository<T> and return
		IGenericRepository<TEntity,TKey> Repository<TEntity,TKey>() where TEntity: BaseEntity<TKey>;
	}
}
