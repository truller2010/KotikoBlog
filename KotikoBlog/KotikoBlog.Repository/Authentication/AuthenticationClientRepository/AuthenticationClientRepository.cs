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
using KotikoBlog.Models.Authentication.AuthenticationClient;
using KotikoBlog.Repository.Abstract;

#endregion

namespace KotikoBlog.Repository.Authentication.AuthenticationClientRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationClientRepository : HibernateDao, IAuthenticationClientRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Save(AuthenticationClient entity)
        {
            return (string) CurrentSession.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Save(IList<AuthenticationClient> entity)
        {
            SaveAll(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AuthenticationClient entity)
        {
            CurrentSession.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationClient Get(string id)
        {
            return CurrentSession.Get<AuthenticationClient>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<AuthenticationClient> GetAll()
        {
            return GetAll<AuthenticationClient>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<AuthenticationClient> Paginated(PageRequest pageRequest)
        {
            return Paginated<AuthenticationClient>(CurrentSession.QueryOver<AuthenticationClient>(), pageRequest);
        }
    }
}