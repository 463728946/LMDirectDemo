using Autofac;
using LMDirect.Framework.Settings;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Db.Autofac
{
    public class SqlSugarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
                {
                    var client = new SqlSugarClient(new ConnectionConfig()
                    {
                        ConnectionString = AppSettingConfig.SqlConnectionString,
                        DbType = DbType.MySql,                        
                        IsAutoCloseConnection = true,
                        InitKeyType = InitKeyType.Attribute
                    });                   
                    return client;
                })
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<SugarRepository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
