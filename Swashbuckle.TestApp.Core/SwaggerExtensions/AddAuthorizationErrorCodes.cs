﻿using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Core.Swagger;

namespace Swashbuckle.TestApp.Core.SwaggerExtensions
{
    public class AddAuthorizationErrorCodes : IOperationFilter
    {
        public void Apply(Operation operation, DataTypeRegistry dataTypeRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.ActionDescriptor.GetFilters().OfType<AuthorizeAttribute>().Any())
            {
                operation.ResponseMessages.Add(new ResponseMessage
                {
                    Code = (int)HttpStatusCode.Unauthorized,
                    Message = "Authentication required"
                });
            }
        }
    }
}