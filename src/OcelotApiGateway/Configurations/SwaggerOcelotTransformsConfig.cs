﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OcelotApiGateway.Configurations
{
    public static class SwaggerOcelotTransformsConfig
    {
        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            // ... alter upstream json
            return swagger.ToString(Formatting.Indented);
        }
    }
}
