using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB5_MAUIDATA.Models;

namespace LAB5_MAUIDATA.Interfaces
{
    public interface IDataRepository
    {
        Task<Bank[]> GetBankAsync();

        Task<Account[]> GetBankAccountAsync(int bankId);

        Task DeleteAccount(int bankId, int accountId);
        Task UpdateBankAsync(Bank bank);
        Task UpdateAccountAsync(Account account);
    }

}
