using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Middleware.Demo.Middlewares;

namespace Middleware.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Use ָ��ȫ���м��
            //app.Use(async (context, next) =>
            //{
            //    // ��ִ�� nextʱ���յ���������Ӧ��������� Hello����Ϊ��ǰ�м��ע������磬���Ҷ�·�˺����м����
            //    ////await context.Response.WriteAsync("Hello");
            //    //await next();

            //    // ִ���� next����ִ��Response.Write���������Ϊһ�� Response ��ʼ������Ͳ��ܶ� header ���в����ˡ�
            //    if (context.Response.HasStarted)
            //    {
            //        //һ���Ѿ���ʼ������������޸���Ӧͷ������
            //    }
            //    await context.Response.WriteAsync("Hello2");
            //});
            #endregion

            #region Map ���ض�·�ɵ�ַָ���м�
            // builder.Use��builder.Run��������
            //      use ��ָ���ǿ�����ע��һ���������м��һ���������ǵ� next Ҳע����������м���п��Ծ����Ƿ�ִ�к������м��
            //      Run ���ʾ��ǰ�߼�Ϊ�м��ִ�е�ĩ�ˣ����ټ���ִ�к�����м����ֱ�ӷ�����

            //app.Map("/abc", abcBuilder =>
            //{
            //    abcBuilder.Use(async (context, next) =>
            //    {
            //        //await context.Response.WriteAsync("Hello");
            //        await next();
            //        await context.Response.WriteAsync("Hello2");
            //    });
            //});

            //app.MapWhen(context => {
            //    return context.Request.Query.Keys.Contains("abc");
            //}, builder =>
            //{
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("new abc");
            //    });
            //});
            #endregion

            #region �Զ����м��
            //app.UseMyMiddleware();
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
