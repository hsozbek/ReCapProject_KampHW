using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRapository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
