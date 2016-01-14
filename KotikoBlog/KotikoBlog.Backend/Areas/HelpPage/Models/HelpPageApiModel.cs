#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Backend
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   15:11
// //
// // File Modified on 14/01/2016/   15:11
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
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Web.Http.Description;
using KotikoBlog.Backend.Areas.HelpPage.ModelDescriptions;

#endregion

namespace KotikoBlog.Backend.Areas.HelpPage.Models
{
    /// <summary>
    ///     The model that represents an API displayed on the help page.
    /// </summary>
    public class HelpPageApiModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HelpPageApiModel" /> class.
        /// </summary>
        public HelpPageApiModel()
        {
            UriParameters = new Collection<ParameterDescription>();
            SampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
            SampleResponses = new Dictionary<MediaTypeHeaderValue, object>();
            ErrorMessages = new Collection<string>();
        }

        /// <summary>
        ///     Gets or sets the <see cref="ApiDescription" /> that describes the API.
        /// </summary>
        public ApiDescription ApiDescription { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ParameterDescription" /> collection that describes the URI parameters for the API.
        /// </summary>
        public Collection<ParameterDescription> UriParameters { get; private set; }

        /// <summary>
        ///     Gets or sets the documentation for the request.
        /// </summary>
        public string RequestDocumentation { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ModelDescription" /> that describes the request body.
        /// </summary>
        public ModelDescription RequestModelDescription { get; set; }

        /// <summary>
        ///     Gets the request body parameter descriptions.
        /// </summary>
        public IList<ParameterDescription> RequestBodyParameters
        {
            get { return GetParameterDescriptions(RequestModelDescription); }
        }

        /// <summary>
        ///     Gets or sets the <see cref="ModelDescription" /> that describes the resource.
        /// </summary>
        public ModelDescription ResourceDescription { get; set; }

        /// <summary>
        ///     Gets the resource property descriptions.
        /// </summary>
        public IList<ParameterDescription> ResourceProperties
        {
            get { return GetParameterDescriptions(ResourceDescription); }
        }

        /// <summary>
        ///     Gets the sample requests associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleRequests { get; private set; }

        /// <summary>
        ///     Gets the sample responses associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleResponses { get; private set; }

        /// <summary>
        ///     Gets the error messages associated with this model.
        /// </summary>
        public Collection<string> ErrorMessages { get; private set; }

        private static IList<ParameterDescription> GetParameterDescriptions(ModelDescription modelDescription)
        {
            var complexTypeModelDescription = modelDescription as ComplexTypeModelDescription;
            if (complexTypeModelDescription != null)
            {
                return complexTypeModelDescription.Properties;
            }

            var collectionModelDescription = modelDescription as CollectionModelDescription;
            if (collectionModelDescription != null)
            {
                complexTypeModelDescription =
                    collectionModelDescription.ElementDescription as ComplexTypeModelDescription;
                if (complexTypeModelDescription != null)
                {
                    return complexTypeModelDescription.Properties;
                }
            }

            return null;
        }
    }
}