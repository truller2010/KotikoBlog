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
using System.Linq;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Repository.Abstract;
using NHibernate.Linq;

#endregion

namespace KotikoBlog.Repository.Authentication.AuthenticationUsersRepository
{
    public class AuthenticationUsersRepository : HibernateDao, IAuthenticationUsersRepository
    {
        public AuthenticationUsers Get(long id)
        {
            return CurrentSession.Get<AuthenticationUsers>(id);
        }

        public IList<AuthenticationUsers> GetAll()
        {
            return GetAll<AuthenticationUsers>();
        }

        public long Save(AuthenticationUsers entity)
        {
            return (long) CurrentSession.Save(entity);
        }

        public void Save(IList<AuthenticationUsers> entities)
        {
            SaveAll(entities);
        }

        public void Update(AuthenticationUsers entity)
        {
            CurrentSession.Update(entity);
        }

        public AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword)
        {
            return CurrentSession.QueryOver<AuthenticationUsers>()
                .Where(u => u.Nombre == username && u.Password == hashedPassword)
                .List().FirstOrDefault();
        }

        public bool ActualizarContrasenia(long CUKotikoBlog, string passOld, string passNew)
        {
            var user =
                CurrentSession.QueryOver<AuthenticationUsers>().Where(x => x.Password == passOld).SingleOrDefault();

            if (user != null)
            {
                user.Password = passNew;
                CurrentSession.Update(user);
                return true;
            }
            return false;
        }

        public Page<AuthenticationUsers> Paginated(PageRequest pageRequest)
        {
            return Paginated<AuthenticationUsers>(CurrentSession.CreateCriteria<AuthenticationUsers>(), pageRequest);
        }

        public IQueryable<AuthenticationUsers> GetAllQueryable()
        {
            return CurrentSession.Query<AuthenticationUsers>();
        }

        public Page<AuthenticationUsers> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            AuthenticationUsers u = null;
            var qUsuarios2 = CurrentSession.Query<AuthenticationUsers>();
            return Paginated(qUsuarios2, filter.PageRequest);
        }

        public AuthenticationUsers GetByEmail(string email)
        {
            return CurrentSession.QueryOver<AuthenticationUsers>()
                .Where(u => u.Email == email)
                .List().FirstOrDefault();
        }


        public bool UserHasLockCode(LockCode locked)
        {
            var status = false;
            status = CurrentSession.Query<AuthenticationUsers>()
                .Where(u => u.Email == locked.email && u.Nombre == locked.username && u.LockedCode == locked.lockCode)
                .ToList().Count() > 0
                ? true
                : false;

            return status;
        }
    }
}