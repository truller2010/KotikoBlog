#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Backend
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   14:38
// //
// // File Modified on 14/01/2016/   14:38
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

using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using KotikoBlog.Backend.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Service.Authentication.AuthenticationUsersService;

#endregion

namespace KotikoBlog.Backend.Controllers.Authentication
{
    public class AuthenticationUsersController : BaseApiController
    {
        private IAuthenticationUsersService AuthenticationUsersService { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Throw()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var user = AuthenticationUsersService.Get(id);

            return Ok(Mapper.Map<AuthenticationUsersResponse>(user));
        }

        [HttpGet]
        public IEnumerable<AuthenticationUsers> GetAll()
        {
            IEnumerable<AuthenticationUsers> users = AuthenticationUsersService.GetAll();

            return Mapper.Map<IEnumerable<AuthenticationUsers>>(users);
        }

        [HttpGet]
        public AuthenticationUsersResponse GetByEmail(string email)
        {
            var user = AuthenticationUsersService.GetByEmail(email);

            return Mapper.Map<AuthenticationUsersResponse>(user);
        }

        [HttpGet]
        public AuthenticationUsersResponse GetByEmail(string email, string password)
        {
            var user = AuthenticationUsersService.GetByUsernameAndPassword(email, password);

            return Mapper.Map<AuthenticationUsersResponse>(user);
        }

        [HttpPost]
        public AuthenticationUsersResponse Save(AuthenticationUsers entity)
        {
            var user = AuthenticationUsersService.Save(entity);

            return Mapper.Map<AuthenticationUsersResponse>(entity);
        }

        [HttpPost]
        public IHttpActionResult Update(AuthenticationUsers entity)
        {
            AuthenticationUsersService.Update(entity);

            return Ok(Mapper.Map<AuthenticationUsersResponse>(entity));
        }

        [HttpPost]
        public Page<AuthenticationUsersResponse> Find(FindRequestImpl<SearchFilter> filter)
        {
            var users = AuthenticationUsersService.Paginated(filter);

            return Mapper.Map<Page<AuthenticationUsersResponse>>(users);
        }

        [HttpPost]
        public bool checkLockCode(LockCode locked)
        {
            return AuthenticationUsersService.UserHasLockCode(locked);
        }

        //AuthenticationUsersService.Paginated
    }
}