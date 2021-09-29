using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public interface ICrudAsync<T>
	{
		public Task<List<T>> GetAllAsync();

		//public T GetAsync(int id);

		//public void UpdateAsync(T item);

		//public void DeleteAsync(int id);
	}
}
