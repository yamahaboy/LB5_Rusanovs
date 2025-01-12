using LAB5_MAUIDATA.Interfaces;
using LAB5_MAUIDATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5_MAUIDATA.Services
{
    public class ApiDataRepository : IDataRepository
    {
        private readonly IBankApiClient _bankApiClient;

        public ApiDataRepository(IBankApiClient apiClient)
        {
            _bankApiClient = apiClient;
        }

        public async Task<Bank[]> GetBankAsync()
        {
            var result = await _bankApiClient.GetItemsAsync<Bank>(BankApiConstants.BanksUrl);
            return result;
        }

        public async Task DeleteAccount(int bankId, int accountId)
        {
            await _bankApiClient
                .DeleteItemAsync($"{BankApiConstants.BanksUrl}/{bankId}/{BankApiConstants.AccountsUrl}/{accountId}");
        }


        public async Task<Account[]> GetBankAccountAsync(int bankId)
        {
            var result = await _bankApiClient

                .GetItemsAsync<Account>($"{BankApiConstants.BanksUrl}/{bankId}/{BankApiConstants.AccountsUrl}");
            return result;
        }

        public async Task UpdateBankAsync(Bank bank)
        {
            await _bankApiClient.UpdateItem<Bank>($"{BankApiConstants.BanksUrl}/{bank.Id}", bank);
        }


        public async Task UpdateAccountAsync(Account account)
        {
            await _bankApiClient.UpdateItem<Account>($"{BankApiConstants.AccountsUrl}/{account.Id}", account);
        }

    }
}
