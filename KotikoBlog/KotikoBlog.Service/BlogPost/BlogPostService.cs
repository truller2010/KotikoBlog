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
using KotikoBlog.Models.BlogArchives;
using KotikoBlog.Models.BlogPost;
using KotikoBlog.Repository.BlogPost;
using Spring.Transaction.Interceptor;

#endregion

namespace KotikoBlog.Service.BlogPost
{
    public class BlogPostService : IBlogPostService
    {
        public IBlogPostRepository BlogPostRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public BlogPostModel Get(int id)
        {
            return BlogPostRepository.Get(id);
        }

        [Transaction(ReadOnly = true)]
        public ICollection<BlogPostModel> GetAll()
        {
            return BlogPostRepository.GetAll();
        }


        [Transaction]
        public int SaveOrUpdate(BlogPostModel entity)
        {
            if (entity.ID != 0)
            {
                var dbEntity = BlogPostRepository.Get(entity.ID);
                if (dbEntity != null)
                {
                    BlogPostRepository.Update(dbEntity);

                    return dbEntity.ID;
                }
                throw new ArgumentException("Invalid id");
            }
            return BlogPostRepository.Save(entity);
        }

        [Transaction]
        public int Save(BlogPostModel entity)
        {
            return BlogPostRepository.Save(entity);
        }

        [Transaction]
        public void Update(BlogPostModel entity)
        {
            BlogPostRepository.Update(entity);
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.Paginated(filter);
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByTag(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByTag(filter);
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByCategory(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByCategory(filter);
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByIdTitle(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByIdTitle(filter);
        }

        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByArchives(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByArchives(filter);
        }

        [Transaction(ReadOnly = true)]
        public BlogArchivesModel GetArchives(int year)
        {
            return BlogPostRepository.GetArchives(year);
        }
    }
}