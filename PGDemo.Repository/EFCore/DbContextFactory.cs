using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PGDemo.Common;
using PGDemo.Common.EFLog;
using PGDemo.Repository.EFCore.dbcontext;
using System;
using System.Collections.Concurrent;

namespace PGDemo.Repository.EFCore
{
    public class DbContextFactory
    {
        private const string AssemblePath = "PGDemo.Repository.EFCore.dbcontext";
        private readonly string _connectionStr;
        private readonly LoggerFactory _logger;

        private DbContextFactory()
        {
            _connectionStr = ConfigHelper.GetValue("ConnectionStrings:PGDemo");

            _logger = new LoggerFactory();
            _logger.AddProvider(new EFLoggerProvider());
        }

        public static DbContextFactory Instance { get; } = new DbContextFactory();

        /// <summary>
        /// dbContext 格式：DB模型名称 + DbContext
        /// DB模型名称
        /// </summary>
        protected ConcurrentDictionary<string, DbContext> DbContextPool = new ConcurrentDictionary<string, DbContext>();

        public DbContext GetDbContext<T>()
        {
            var modelTypeName = typeof(T).Name;
            
            DbContextPool.TryGetValue(modelTypeName, out DbContext dbContext);
            if (dbContext == null)
            {
                var dbContextTypeName = $"{AssemblePath}.{modelTypeName}DbContext";
                try
                {
                    var instanceType = Type.GetType(dbContextTypeName);

                    var opetionsType = typeof(DbContextOptionsBuilder<>).MakeGenericType(instanceType);
                    var options =  (DbContextOptionsBuilder)Activator.CreateInstance(opetionsType, true);
                    options.UseNpgsql(_connectionStr).UseLoggerFactory(_logger);

                    dbContext = (DbContext)Activator.CreateInstance(instanceType, new object[] { options.Options });
                    
                    if (dbContext != null)
                    {
                        DbContextPool.TryAdd(modelTypeName, dbContext);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (dbContext == null)
            {
                modelTypeName = "Default";

                DbContextPool.TryGetValue(modelTypeName, out dbContext);

                if (dbContext == null)
                {
                    var options = new DbContextOptionsBuilder<DefaultDbContext>();
                    options.UseNpgsql(_connectionStr).UseLoggerFactory(_logger);
                    
                    dbContext = new DefaultDbContext(options.Options);

                    DbContextPool.TryAdd(modelTypeName, dbContext);
                } 
            }

            return dbContext;
        }
    }
}
