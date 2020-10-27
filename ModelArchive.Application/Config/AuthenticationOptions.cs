using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Application.Config
{
    public class AuthenticationOptions
    {
        public SignInOptions SignIn { get; set; }
        public PasswordOptions Password { get; set; }
        public UserOptions User { get; set; }
        public LockoutOptions Lockout { get; set; }
        public CookieOptions Cookie { get; set; }
    }

    /// <summary>
    /// SignIn options for authentication
    /// </summary>
    public class SignInOptions
    {
        public bool RequireConfirmedEmail { get; set; } = false;
    }

    /// <summary>
    /// Password options for authentication
    /// </summary>
    public class PasswordOptions
    {
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public int RequiredUniqueChars { get; set; }
        public int RequiredLength { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
    }

    /// <summary>
    /// User options for authentication
    /// </summary>
    public class UserOptions
    {
        public string AllowedUserNameCharacters { get; set; }
        public bool RequireUniqueEmail { get; set; }
    }

    /// <summary>
    /// Lockout options for authentication
    /// </summary>
    public class LockoutOptions
    {
        public int DefaultLockoutTimeSpan { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
        public bool AllowedForNewUsers { get; set; }
    }

    /// <summary>
    /// Cookie options for authentication
    /// </summary>
    public class CookieOptions
    {
        public bool HttpOnly { get; set; }
        public int ExpireTimeSpan { get; set; }
        public bool SlidingExpiration { get; set; }
    }
}
