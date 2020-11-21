using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aiursoft.DocGenerator.Middlewares;
using DocGenerator.Abstract.Attributes;

namespace DocGenerator
{
    public class APIDocGeneratorSettings
    {
        public Func<MethodInfo, Type, bool> IsAPIAction { get; set; } = (action, controller) =>
        {
            return
                action.CustomAttributes.Any(t => t.AttributeType == typeof(GenerateDoc)) ||
                controller.CustomAttributes.Any(t => t.AttributeType == typeof(GenerateDoc));
        };

        public Func<MethodInfo, Type, bool> JudgeAuthorized { get; set; } = (action, controller) =>
        {
            return
                action.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorizeAttribute)) ||
                controller.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorizeAttribute));
        };
        public List<object> GlobalPossibleResponse { get; set; } = new List<object>();
        public DocFormat Format = DocFormat.Json;
        public string DocAddress = "doc";
    }
    public static class Extends
    {
        public static IApplicationBuilder UseDocGenerator(
            this IApplicationBuilder app,
            Action<APIDocGeneratorSettings> options = null)
        {
            var defaultSettings = new APIDocGeneratorSettings();
            options?.Invoke(defaultSettings);
            APIDocGeneratorMiddleware.ApplySettings(defaultSettings);
            return app.UseMiddleware<APIDocGeneratorMiddleware>();
        }
    }
}
