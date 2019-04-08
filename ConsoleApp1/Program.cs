using Czar.Cms.Core.CodeGenerator;
using Czar.Cms.Core.Models;
using Czar.Cms.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratorModelForSqlServer();
        }
        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();

            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=.;Initial Catalog=CzarCms;Integrated Security=True";//这个必须
                options.DbType = DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType//这个也必须
                options.Author = "wuhc";//作者名称，随你，不写为空
                options.OutputPath = @"E:\NetCore\Cms.Models";//实体模型输出路径，为空则默认为当前程序运行的路径
                options.ModelsNamespace = "Cms.Models";//实体命名空间
            });
            services.AddSingleton<CodeGenerator>();//注入Model代码生成器
            return services.BuildServiceProvider(); //构建服务提供程序
        }
        public static void GeneratorModelForSqlServer()
        {
            var serviceProvider = BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase();

        }
    }
}
