﻿using System.Reflection;

using Microsoft.AspNetCore.Mvc;

namespace SFC.Scheme.Api.Infrastructure;

public static class ApiRegistration
{
    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.Configure<MvcOptions>(options => options.AllowEmptyInputInBodyModelBinding = true);
        builder.Services.AddCors();
    }
}