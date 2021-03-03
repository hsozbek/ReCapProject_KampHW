using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User rental);
        IResult Delete(User rental);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Update(User rental);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}
