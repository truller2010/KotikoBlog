#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Service
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   14:52
// //
// // File Modified on 14/01/2016/   14:52
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System.Collections.Generic;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Repository.Authentication.AuthenticationUsersRepository;
using Spring.Transaction.Interceptor;

#endregion

namespace KotikoBlog.Service.Authentication.AuthenticationUsersService
{
    internal class AuthenticationUsersService : IAuthenticationUsersService
    {
        public IAuthenticationUsersRepository AuthenticationUsersRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public AuthenticationUsers Get(long id)
        {
            return AuthenticationUsersRepository.Get(id);
        }

        [Transaction(ReadOnly = true)]
        public ICollection<AuthenticationUsers> GetAll()
        {
            return AuthenticationUsersRepository.GetAll();
        }

        [Transaction]
        public long Save(AuthenticationUsers entity)
        {
            var id = AuthenticationUsersRepository.Save(entity);

            return id;
        }

        [Transaction]
        public void Update(AuthenticationUsers entity)
        {
            AuthenticationUsersRepository.Update(entity);
        }

        [Transaction(ReadOnly = true)]
        public Page<AuthenticationUsers> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            return AuthenticationUsersRepository.Paginated(filter);
        }

        [Transaction(ReadOnly = true)]
        public AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword)
        {
            return AuthenticationUsersRepository.GetByUsernameAndPassword(username, hashedPassword);
        }

        [Transaction(ReadOnly = true)]
        public AuthenticationUsers GetByEmail(string email)
        {
            return AuthenticationUsersRepository.GetByEmail(email);
        }

        [Transaction]
        public bool ActualizarContrasenia(long id, string passOld, string passNew)
        {
            return AuthenticationUsersRepository.ActualizarContrasenia(id, passOld, passNew);
        }

        [Transaction(ReadOnly = true)]
        public bool UserHasLockCode(LockCode locked)
        {
            return AuthenticationUsersRepository.UserHasLockCode(locked);
        }
    }
}