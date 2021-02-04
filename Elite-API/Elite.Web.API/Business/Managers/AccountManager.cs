using AutoMapper;
using Elite.Web.API.Database.Repositories.Interfaces;
using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Extentions;
using Elite.Web.API.Others.Models;

namespace Elite.Web.API.Business.Managers
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;
        private readonly IMapper _autoMapper;
        public AccountManager(IAccountRepository accountRepository, IMapper autoMapper)
        {
            _accountRepository = accountRepository;
            _autoMapper = autoMapper;
        }

        public int Register(AccountDTO register)
        {
            // convert AccountDTO to Account object using auto mapper 
            register.Password = PasswordExtention.GenerateUserPassword(register.Password);
            var autoMap = _autoMapper.Map<Account>(register);
            var result = _accountRepository.Create(autoMap);
            return result;
        }

        public int? Login(LoginDTO login)
        {
            var account = new Account
            {
                Phone = login.Phone,
                Password = PasswordExtention.GenerateUserPassword(login.Password)
            };
            var result = _accountRepository.Get(account);

            return result?.Id;
        }
    }
}
