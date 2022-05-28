using Core.Entities.Concrete;
using Core.Entities.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Burada login ve register yapılacak işlemler yazıyor.
    // BU Servis Sayesinde ben sisteme ya register yad login olmuş olacagım.
    //Login demek veritabanında olan birinin kontrol edilmesidir.
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        //User İçim token oluşturulması için yazılıyor.
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
