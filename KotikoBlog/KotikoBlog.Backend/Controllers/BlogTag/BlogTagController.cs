﻿#region KotikoBlog Header License

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
using KotikoBlog.Backend.Models.BlogTag;
using KotikoBlog.Core.Filter;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.BlogTag;
using KotikoBlog.Service.BlogTag;
using NHibernate.Exceptions;
using Oracle.ManagedDataAccess.Client;
using Spring.Data.NHibernate;

#endregion

namespace KotikoBlog.Backend.Controllers.BlogTag
{
    [ErrorHandler]
    //[Authorize]
    public class BlogTagController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public IBlogTagService BlogTagService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(Mapper.Map<IEnumerable<BlogTagResponse>>(BlogTagService.GetAll()));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var item = BlogTagService.Get(id);
                if (item != null)
                {
                    return Ok(Mapper.Map<BlogTagResponse>(item));
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Save(BlogTagModel item)
        {
            try
            {
                if (item != null)
                {
                    BlogTagService.SaveOrUpdate(item);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Find(FindRequestImpl<SearchFilter> filter)
        {
            try
            {
                var page = BlogTagService.Paginated(filter);

                return Ok(Mapper.Map<Page<BlogTagModel>>(page));
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}