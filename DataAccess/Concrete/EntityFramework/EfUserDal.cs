using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, YıldızContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            using (var context = new YıldızContext())
            {
                var result = from user in context.Users
                             select new UserDetailDto
                             {
                                 UserId = user.Id,
                                 FullName = $"{user.FirstName} {user.LastName}",
                                
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new YıldızContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();

            }
        }
    }
}
