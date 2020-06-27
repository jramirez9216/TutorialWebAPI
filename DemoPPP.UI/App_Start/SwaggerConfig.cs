using System.Web.Http;
using WebActivatorEx;
using DemoPPP.UI;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DemoPPP.UI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "DemoPPP.UI");
                        c.PrettyPrint();
                        c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }

    /// <summary>
    /// AuthorizationHeaderParameterOperationFilter para introducir el JWT en el Dialogo de swagger
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter()
            {
                name ="Authorization",
                @in="header",
                description ="JWT Token",
                required=true,
                type= "string"
            });
        }
    }
}
