using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Framework.Settings
{
    public class AppSettingConfig
    {
        private static string AppSettingValue([CallerMemberName]string key = null)
        {
            return ConfigurationManager.AppSettings[key];
        }



        public static string MongoUrl => AppSettingValue();
        
        public static string MongoDatabase => AppSettingValue();
        public static string TransportType => AppSettingValue();

        public static string Hosting => AppSettingValue();

        public static string BaseQueueName => AppSettingValue();

        public static string RabbitMqBaseUri => AppSettingValue();

        public static string RabbitMqUserName => AppSettingValue();

        public static string RabbitMqUserPassword => AppSettingValue();

        //public static string RabbitMqIdentityHeaderKey => AppSettingValue();

        //public static string ReadModelRabbitMqBaseUri => AppSettingValue();

        //public static string ReadModelRabbitMqUserName => AppSettingValue();

        //public static string ReadModelRabbitMqUserPassword => AppSettingValue();

        public static string RpcQueueNamePostfix => AppSettingValue();

        public static string CommandQueueNamePostfix => AppSettingValue();

        public static string EventQueueNamePostfix => AppSettingValue();

        //public static string ReadModelQueueNamePostfix => AppSettingValue();

        //public static bool RedisCachingEnabled
        //{
        //    get
        //    {
        //        bool.TryParse(AppSettingValue(), out var redisCachingEnabled);
        //        return redisCachingEnabled;
        //    }
        //}

        //public static string SeqSinkServerAddress => AppSettingValue();
        //public static string AttachmentUploadPath => AppSettingValue();

        //public static bool SslRequirement => Convert.ToBoolean(AppSettingValue());
        //public static string SAPAddress => AppSettingValue();

       
        
    }
}
