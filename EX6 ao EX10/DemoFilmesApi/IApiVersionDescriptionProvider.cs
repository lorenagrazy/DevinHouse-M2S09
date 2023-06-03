using System.Collections.Generic;

namespace DemoFilmesApi
{
    internal interface IApiVersionDescriptionProvider
    {
        IEnumerable<object> ApiVersionDescriptions { get; }
    }
}