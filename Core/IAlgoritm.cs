using System.Collections.Generic;
using System.Threading.Tasks;

using FermaLib;

namespace Core
{

	public interface IAlgoritm
	{
		IEnumerable<IPoint2D> GetPosition();

		async Task<IEnumerable<IPoint2D>> GetPositionAsync() => await Task.Run(GetPosition);
	}

}