using System.Collections.Generic;

namespace CoreStarter.Core.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400) { }

        public IEnumerable<string> Errors { get; set; }
    }
}