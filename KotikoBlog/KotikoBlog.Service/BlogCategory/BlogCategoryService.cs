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

using System;
using System.Collections.Generic;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.BlogCategory;
using KotikoBlog.Repository.BlogCategory;
using Spring.Transaction.Interceptor;

#endregion

namespace KotikoBlog.Service.BlogCategory
{
    public class BlogCategoryService : IBlogCategoryService
    {
        public IBlogCategoryRepository BlogCategoryRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public BlogCategoryModel Get(int id)
        {
            return BlogCategoryRepository.Get(id);
        }

        [Transaction(ReadOnly = true)]
        public ICollection<BlogCategoryModel> GetAll()
        {
            return BlogCategoryRepository.GetAll();
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogCategoryModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            return BlogCategoryRepository.Paginated(filter);
        }


        [Transaction]
        public int SaveOrUpdate(BlogCategoryModel entity)
        {
            if (entity.ID != 0)
            {
                var dbEntity = BlogCategoryRepository.Get(entity.ID);
                if (dbEntity != null)
                {
                    BlogCategoryRepository.Update(dbEntity);

                    return dbEntity.ID;
                }
                throw new ArgumentException("Invalid id");
            }
            return BlogCategoryRepository.Save(entity);
        }

        [Transaction]
        public int Save(BlogCategoryModel entity)
        {
            return BlogCategoryRepository.Save(entity);
        }

        [Transaction]
        public void Update(BlogCategoryModel entity)
        {
            BlogCategoryRepository.Update(entity);
        }
    }
}