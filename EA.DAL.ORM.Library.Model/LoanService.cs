﻿using EA.DAL.ORM.Library.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.ORM.Library.Model
{
    public class LoanService
    {
        private IMemberRepository _memberRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        public LoanService(IBookRepository bookRepository,
                           IMemberRepository memberRepository,
                           IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public Loan Loan(Guid memberId, Guid bookId)
        {
            Loan loan = default(Loan);
            Book book = _bookRepository.FindBy(bookId);
            Member member = _memberRepository.FindBy(memberId);

            if (member.CanLoan(book))
            {
                member.Loan(book);
                book.OnLoanTo = member;
                _memberRepository.Save(member);
                _bookRepository.Save(book);
                _unitOfWork.Commit();
            }

            return loan;
        }

        public void Return(Guid bookId)
        {
            Book book = _bookRepository.FindBy(bookId);
            Member member = book.OnLoanTo;

            member.Return(book);

            _memberRepository.Save(member);
            _bookRepository.Save(book);
            _unitOfWork.Commit();
        }
    }
}
