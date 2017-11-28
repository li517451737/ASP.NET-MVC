using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Users;

namespace TP.Core.IdentityConfig
{
    /// <summary>
    /// 配置此应用程序中使用的用户管理器。UserManager是ASP.NET Identity中定义的
    /// </summary>
    public class TPUserManager : UserManager<User>
    {

        public TPUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static TPUserManager Create(IdentityFactoryOptions<TPUserManager> options,
            IOwinContext context)
        {
            var manager = new TPUserManager(new UserStore<User>(context.Get<TPDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<User>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("TP MVC Identity"));
            }
            return manager;
        }
    }
    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class TPRoleManager : RoleManager<IdentityRole>
    {
        public TPRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static TPRoleManager Create(IdentityFactoryOptions<TPRoleManager> options, IOwinContext context)
        {
            return new TPRoleManager(new RoleStore<IdentityRole>(context.Get<TPDbContext>()));
        }
    }

    public class TPSignInManager : SignInManager<User, string>
    {
        public TPSignInManager(TPUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((TPUserManager)UserManager);
        }

        public static TPSignInManager Create(IdentityFactoryOptions<TPSignInManager> options, IOwinContext context)
        {
            return new TPSignInManager(context.GetUserManager<TPUserManager>(), context.Authentication);
        }
    }


    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
