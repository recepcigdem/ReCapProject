using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), true, Messages.Get);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id), true, Messages.Get);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           _userDal.Add(user);
           return new SuccessResult(Messages.Add);
        }
        [ValidationAspect(typeof(UserValidator))]
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
    }
}
