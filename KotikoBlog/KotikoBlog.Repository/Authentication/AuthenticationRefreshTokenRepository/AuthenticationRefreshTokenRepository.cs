#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Repository
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   14:54
// //
// // File Modified on 14/01/2016/   14:54
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
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.Authentication.AuthenticationRefreshToken;
using KotikoBlog.Repository.Abstract;

#endregion

namespace KotikoBlog.Repository.Authentication.AuthenticationRefreshTokenRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationRefreshTokenRepository : HibernateDao, IAuthenticationRefreshTokenRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Save(AuthenticationRefreshToken entity)
        {
            return (string) CurrentSession.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Save(IList<AuthenticationRefreshToken> entity)
        {
            SaveAll(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AuthenticationRefreshToken entity)
        {
            CurrentSession.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationRefreshToken Get(string id)
        {
            return CurrentSession.Get<AuthenticationRefreshToken>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<AuthenticationRefreshToken> GetAll()
        {
            return GetAll<AuthenticationRefreshToken>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<AuthenticationRefreshToken> Paginated(PageRequest pageRequest)
        {
            return Paginated<AuthenticationRefreshToken>(CurrentSession.QueryOver<AuthenticationRefreshToken>(),
                pageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AuthenticationRefreshToken entity)
        {
            CurrentSession.Delete(entity);
        }
    }
}