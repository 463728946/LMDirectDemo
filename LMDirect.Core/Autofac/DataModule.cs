using Autofac;
using LMDirect.Framework.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Core.Autofac
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
                {
                    var client = new MongoClient(AppSettingConfig.MongoUrl);
                    return client.GetDatabase(AppSettingConfig.MongoDatabase);
                }
            );
            builder.RegisterType<MongoRepository>().As<IMongoRepository>().InstancePerLifetimeScope();
        }
    }
}
