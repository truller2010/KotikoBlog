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

using KotikoBlog.Core.Filter;
using KotikoBlog.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Repository.Abstract;

#endregion

namespace KotikoBlog.Repository.Authentication.AuthenticationUsersRepository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationUsersRepository :
        ISupportsSave<AuthenticationUsers, long>,
        IDao<AuthenticationUsers, long>,
        IQueryableDao<AuthenticationUsers, long>,
        ISearchableDao<AuthenticationUsers, long, SearchFilter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        AuthenticationUsers GetByEmail(string email);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CUKotikoBlog"></param>
        /// <param name="passOld"></param>
        /// <param name="passNew"></param>
        /// <returns></returns>
        bool ActualizarContrasenia(long CUKotikoBlog, string passOld, string passNew);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locked"></param>
        /// <returns></returns>
        bool UserHasLockCode(LockCode locked);
    }
}