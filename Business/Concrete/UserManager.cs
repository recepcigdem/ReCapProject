using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;


namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>( true, Messages.Get, _userDal.GetAll());
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>( true, Messages.Get, _userDal.Get(u => u.Id == id));
        }
        [SecuredOperation("admin,user.add")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
           _userDal.Add(user);
           return new SuccessResult(Messages.Add);
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            
            return new SuccessResult(Messages.Update);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);

            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(true, Messages.Get,_userDal.GetClaims(user));
            
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));

        }
        [TransactionScopeAspect]
        public IResult AddTransactionTest(User user)
        {
            Add(user);

            return null;
        }
    }
}
