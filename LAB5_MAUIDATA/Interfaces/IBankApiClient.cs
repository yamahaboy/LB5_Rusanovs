using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5_MAUIDATA.Interfaces
{
    public interface IBankApiClient
    {
        Task<T[]> GetItemsAsync<T>(string url) where T : class;

        Task DeleteItemAsync(string url);

        Task UpdateItem<T>(string url, T entity) where T : class;

    }
}
