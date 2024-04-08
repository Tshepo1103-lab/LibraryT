using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using LibraryT.Services.BookService.Dto;
using LibraryT.Services.CategoryService.Dto;
using LibraryT.Services.TransactionService.Dto;
using LibraryT.Services.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Abp.UI;

namespace LibraryT.Services.TransactionService
{
    public class TransactionAppService : AsyncCrudAppService<Transaction, TransactionDto, Guid>
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Transaction, Guid> _repository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IAbpSession _abpSession;

        public TransactionAppService(
            IRepository<Book, Guid> bookRepository,
            IRepository<Transaction, Guid> repository,
            IRepository<User,long> userRepository,
            IAbpSession abpSession)
            : base(repository)
        {
            _bookRepository = bookRepository;
            _repository = repository;
            _userRepository = userRepository;
            _abpSession = abpSession;
        }

        public override async Task<TransactionDto> CreateAsync(TransactionDto input)
        {
            var exist = await _repository.FirstOrDefaultAsync(x => x.User.Id == input.UserId && x.Book.Id == input.BookId);
            if (exist == null)
            {
                var transaction = ObjectMapper.Map<Transaction>(input);
                transaction.Book = await _bookRepository.GetAsync(input.BookId);
                transaction.User = await _userRepository.GetAsync(input.UserId);

                transaction.Book.Count++;
                var result = await _repository.InsertAsync(transaction);

                var ts = "0761220403";

                var cell = "+27" + ts.Remove(0, 1);



               Notifications.Notification.SendMessage(cell, $"Your Book is ready to be collected, use this ref num to collect: {result.Id} ");



                return ObjectMapper.Map<TransactionDto>(result);

            }
           else
            {
                throw new UserFriendlyException("Already Requested the book.");
            }
            
        }

        public async Task<List<TransactionDto>> GetAllIncluding(long userId)
        {
            var transactions = await _repository.GetAll()
                                               .Include(e => e.User)
                                               .Include(e => e.Book)
                                               .Where(e => e.User.Id == userId)
                                               .OrderBy(e => e.CheckOutDate)  
                                               .ToListAsync();

            return ObjectMapper.Map<List<TransactionDto>>(transactions);
        }
        public async Task<List<TransactionDto>> GetAllTransactionsIncludingAsync()
        {
            var transactions = await _repository.GetAll()
                                               .Include(e => e.User)
                                               .Include(e => e.Book)
                      
                                               .OrderBy(e => e.CheckOutDate)
                                               .ToListAsync();

            return ObjectMapper.Map<List<TransactionDto>>(transactions);
        }


        [HttpGet]
        public async Task<List<TransactionDto>> GetAllTransactionAsync()
        {
            var transactions = await _repository.GetAllIncluding(x => x.Book).ToListAsync();
            return ObjectMapper.Map<List<TransactionDto>>(transactions);
        }
        [HttpGet]
        public async Task<int> GetTranCountAsync()
        {
            return await _repository.CountAsync(x => x.Status == 0);
        }
    }
}
