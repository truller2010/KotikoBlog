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

using AutoMapper;
using KotikoBlog.Backend.Models.Authentication.AuthenticationUsers;
using KotikoBlog.Core.Pager;
using KotikoBlog.Models.Authentication.AuthenticationUsers;

#endregion

namespace KotikoBlog.Backend.Mapping.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationUsersProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<AuthenticationUsers, AuthenticationUsersResponse>();
            Mapper.CreateMap<Page<AuthenticationUsers>, Page<AuthenticationUsersResponse>>();
            Mapper.CreateMap<AuthenticationUsersResponse, AuthenticationUsers>();
        }
    }
}