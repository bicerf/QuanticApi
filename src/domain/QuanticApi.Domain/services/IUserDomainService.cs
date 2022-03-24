using QuanticApi.Core.domain;
using QuanticApi.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanticApi.Domain.services
{
    public class ApplicationUserResult
    {
        //İşlem başarılı mesajı 
        public bool IsSucceeded { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        //User ile alakalıo operasyonlar esnasında bir hata geldiğinde buradaki hata mesajlarını son kullanıcıya göstereceğiz.
    }
  
    public interface IUserDomainService:IDomainService<ApplicationUser>
    {
        ApplicationUserResult CreateUser(string email, string password);

    }
}
