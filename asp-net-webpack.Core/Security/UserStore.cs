using asp_net_webpack.Core.Request.User;
using asp_net_webpack.Core.Service;
using asp_net_webpack.Core.Service.Role;
using asp_net_webpack.Core.Service.User;
using asp_net_webpack.Core.Service.User.Claim;
using asp_net_webpack.Core.Service.User.UserRole;
using asp_net_webpack.Domain.Model.User;
using asp_net_webpack.Domain.Model.User.Claim;
using asp_net_webpack.Domain.Request.User.Claim;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace asp_net_webpack.Core.Security
{
    // TODO; READ ABOUT ASYNC VS SYNC: https://gokhansengun.com/asp-net-mvc-and-web-api-comparison-of-async-or-sync-actions/
    public class UserStore :
        IUserStore<UserModel>,
        IUserEmailStore<UserModel>,
        IUserPhoneNumberStore<UserModel>,
        IUserTwoFactorStore<UserModel>,
        IUserPasswordStore<UserModel>
    {
        private ServiceContext Services => asp_net_webpackAppContext.Current.Services;
        private UserService UserService => Services.UserService;
        private RoleService RoleService => Services.RoleService;
        private UserRoleService UserRoleService => Services.UserRoleService;
        private UserClaimService UserClaimService => Services.UserClaimService;

        public async Task<IdentityResult> CreateAsync(UserModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.UserId = await UserService.InsertAsync(user, cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(UserModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UserService.DeleteAsync(user, cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<UserModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var request = new UserFilterRequest { UserId = long.Parse(userId) };
            return await UserService.FirstOrDefaultAsync(request, cancellationToken);
        }

        public async Task<UserModel> FindByNameAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new UserFilterRequest { NormalizedEmail = normalizedEmail };
            return await UserService.FirstOrDefaultAsync(request, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId.ToString());
        }

        public Task<string> GetUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(UserModel user, string normalizedUsername, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedUsername;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(UserModel user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(UserModel user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await UserService.UpdateAsync(user, cancellationToken);

            return IdentityResult.Success;
        }

        public Task SetEmailAsync(UserModel user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.IsEmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(UserModel user, bool confirmed, CancellationToken cancellationToken)
        {
            user.IsEmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task<UserModel> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new UserFilterRequest { NormalizedEmail = normalizedEmail };
            return await UserService.SingleOrDefaultAsync(request, cancellationToken);
        }

        public Task<string> GetNormalizedEmailAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task SetNormalizedEmailAsync(UserModel user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(UserModel user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.IsPhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(UserModel user, bool confirmed, CancellationToken cancellationToken)
        {
            user.IsPhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(UserModel user, bool enabled, CancellationToken cancellationToken)
        {
            user.IsTwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.IsTwoFactorEnabled);
        }

        public Task SetPasswordHashAsync(UserModel user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public async Task<IList<UserModel>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task<IList<Claim>> GetClaimsAsync(UserModel user, CancellationToken cancellationToken)
        {
            var userClaim_req = new UserClaimFilterRequest { UserId = user.UserId };
            var userClaim_list = await UserClaimService.GetListAsync(userClaim_req, cancellationToken);
            return userClaim_list.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();
        }

        public async Task AddClaimsAsync(UserModel user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var userClaim_list = claims.Select(x => new UserClaimModel(user.UserId, x.Type, x.Value)).ToList();
            await UserClaimService.InsertAsync(userClaim_list, cancellationToken);
        }

        public async Task ReplaceClaimAsync(UserModel user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            var userClaim_req = new UserClaimFilterRequest { UserId = user.UserId, ClaimType = claim.Type };
            var userClaim = await UserClaimService.FirstOrDefaultAsync(userClaim_req, cancellationToken);
            await UserClaimService.DeleteAsync(userClaim, cancellationToken);

            userClaim.ClaimType = newClaim.Type;
            userClaim.ClaimValue = newClaim.Value;
            await UserClaimService.InsertAsync(userClaim, cancellationToken);
        }
        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}
