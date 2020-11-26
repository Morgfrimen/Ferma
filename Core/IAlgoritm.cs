using FermaLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{

    public interface IAlgoritm
    {
        IEnumerable<IPoint2D> GetPosition();

        async Task<IEnumerable<IPoint2D>> GetPositionAsync()
        {
            return await Task.Run(GetPosition);
        }
    }

}