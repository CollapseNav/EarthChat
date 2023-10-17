﻿using Infrastructure;

namespace Chat.Service.Infrastructure.Middlewares;

public class ReductionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Query.TryGetValue("reduction", out var reduction) && reduction == "true")
        {
            // 检查请求路径，看是否是图片请求，如果是则处理
            var imagePath = context.Request.Path.Value;
            if (imagePath?.IsImage() == true) //您可以根据需要添加其他图片格式
            {
                var ext = Path.GetExtension(context.Request.Path);

                context.Request.Path = new PathString(imagePath.Replace(ext, ".compress" + ext)); // 示例逻辑
            }
        }

        await next(context);
    }
}