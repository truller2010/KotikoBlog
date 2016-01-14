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
using KotikoBlog.Backend.Filters;
using KotikoBlog.Backend.Models.BlogArchives;
using KotikoBlog.Backend.Models.BlogPost;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.BlogPost;
using KotikoBlog.Service.BlogPost;
using NHibernate.Exceptions;
using Oracle.ManagedDataAccess.Client;
using Spring.Data.NHibernate;

#endregion

namespace KotikoBlog.Backend.Controllers.BlogPost
{
    [ErrorHandler]
    //[Authorize]
    public class BlogPostController : ApiController
    {
        public IBlogPostService BlogPostService { get; set; }

        //GET /api/Laboratorios/GetAll
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(Mapper.Map<IEnumerable<BlogPostResponse>>(BlogPostService.GetAll()));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        //GET /api/Laboratorios/Get/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var item = BlogPostService.Get(id);
                if (item != null)
                {
                    return Ok(Mapper.Map<BlogPostResponse>(item));
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        //POST /api/Laboratorios/Save
        [HttpPost]
        public IHttpActionResult Save(BlogPostModel item)
        {
            try
            {
                if (item != null)
                {
                    BlogPostService.SaveOrUpdate(item);
                    return Ok(item);
                }
                return BadRequest("No se ha enviado información que almacenar.");
            }
            catch (HibernateAdoException hibernateException)
            {
                if (hibernateException.InnerException is GenericADOException)
                {
                    if (hibernateException.InnerException.InnerException is OracleException)
                    {
                        return InternalServerError(hibernateException.InnerException.InnerException);
                    }
                    return InternalServerError(hibernateException.InnerException);
                }
                return InternalServerError(hibernateException);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [HttpPost]
        public IHttpActionResult Find(FindRequestImpl<SearchFilter> filter)
        {
            filter.PageRequest.Sort = null;
            try
            {
                var page = BlogPostService.Paginated(filter);

                return Ok(Mapper.Map<Page<BlogPostResponse>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [HttpPost]
        public IHttpActionResult FindByTag(FindRequestImpl<SearchFilter> filter)
        {
            filter.PageRequest.Sort = null;
            try
            {
                var page = BlogPostService.PaginatedByTag(filter);

                return Ok(Mapper.Map<Page<BlogPostResponse>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }


        [HttpPost]
        public IHttpActionResult FindByCategory(FindRequestImpl<SearchFilter> filter)
        {
            filter.PageRequest.Sort = null;
            try
            {
                var page = BlogPostService.PaginatedByCategory(filter);

                return Ok(Mapper.Map<Page<BlogPostResponse>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [HttpPost]
        public IHttpActionResult FindByIdTitle(FindRequestImpl<SearchFilter> filter)
        {
            filter.PageRequest.Sort = null;
            try
            {
                var page = BlogPostService.PaginatedByIdTitle(filter);

                return Ok(Mapper.Map<Page<BlogPostResponse>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [HttpPost]
        public IHttpActionResult FindByArchives(FindRequestImpl<SearchFilter> filter)
        {
            filter.PageRequest.Sort = null;
            try
            {
                var page = BlogPostService.PaginatedByArchives(filter);

                return Ok(Mapper.Map<Page<BlogPostResponse>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        [HttpGet]
        public IHttpActionResult GetArchives()
        {
            try
            {
                var item = BlogPostService.GetArchives(DateTime.Now.Year);
                if (item != null)
                {
                    return Ok(Mapper.Map<BlogArchivesResponse>(item));
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}