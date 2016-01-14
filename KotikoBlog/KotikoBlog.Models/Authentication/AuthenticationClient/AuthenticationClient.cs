#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Models
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

using FluentNHibernate.Mapping;
using KotikoBlog.Models.Authentication.Enums;

#endregion

namespace KotikoBlog.Models.Authentication.AuthenticationClient
{
    public class AuthenticationClient
    {
        public virtual string Id { get; set; }
        public virtual string Secret { get; set; }
        public virtual string Name { get; set; }
        public virtual ApplicationTypes Applicationtype { get; set; }
        public virtual bool Active { get; set; }
        public virtual int Refreshtokenlifetime { get; set; }
        public virtual string Allowedorigin { get; set; }
    }

    public class AuthenticationClientMap : ClassMap<AuthenticationClient>
    {
        public AuthenticationClientMap()
        {
            Table("Authentication_Client");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
            Map(x => x.Secret).Column("Secret").Not.Nullable();
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Applicationtype).Column("ApplicationType").Not.Nullable();
            Map(x => x.Active).Column("Active").Not.Nullable();
            Map(x => x.Refreshtokenlifetime).Column("RefreshTokenLifeTime").Not.Nullable();
            Map(x => x.Allowedorigin).Column("AllowedOrigin").Not.Nullable();
        }
    }
}