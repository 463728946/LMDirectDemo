using LMDirect.Framework.Settings;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.MassTransit.BusSwitcher
{
    public class BusSwitch : IBusSwitch
    {
        private readonly IBus _memoryBus;
        private readonly IBus _rabbitmqBus;

        private readonly Uri _rpcAddress;
        private readonly Uri _commandAddress;
        private readonly TimeSpan _requestTimeout;

        private readonly string _transportType;

        private ISendEndpoint _endPoint;

        public BusSwitch(IBus memoryBus, IBus rabbitmqBus)
        {
            _memoryBus = memoryBus;
            _rabbitmqBus = rabbitmqBus;

            _requestTimeout = TimeSpan.FromSeconds(30);

            _transportType = AppSettingConfig.TransportType;

            _rpcAddress = new Uri(AppSettingConfig.RabbitMqBaseUri + AppSettingConfig.BaseQueueName + "_" + AppSettingConfig.RpcQueueNamePostfix);
            _commandAddress = new Uri(AppSettingConfig.RabbitMqBaseUri + AppSettingConfig.BaseQueueName + "_" + AppSettingConfig.CommandQueueNamePostfix);
        }

        public async Task Send(object message)
        {
            if (_endPoint == null)
            {
                _endPoint = await GetSendEndPoint();
            }

            await _endPoint.Send(message);
        }

        public async Task Publish(object @event)
        {
            if (_transportType.ToUpper() == "RABBITMQ")
                await _rabbitmqBus.Publish(@event);
            else
                await _memoryBus.Publish(@event);
        }

        public async Task<TResponse> Request<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            return await CreateRequestClient<TRequest, TResponse>().Request(request);
        }

        protected IRequestClient<TRequest, TResponse> CreateRequestClient<TRequest, TResponse>(Uri address = null, TimeSpan? requestTimeout = null)
            where TRequest : class
            where TResponse : class
        {
            if (_transportType.ToUpper() == "RABBITMQ")
            {
                return _rabbitmqBus.CreateRequestClient<TRequest, TResponse>(address ?? _rpcAddress, requestTimeout ?? _requestTimeout);
            }

            return _memoryBus.CreateRequestClient<TRequest, TResponse>(address ?? _rpcAddress, requestTimeout ?? _requestTimeout);
        }

        protected async Task<ISendEndpoint> GetSendEndPoint(Uri address = null)
        {
            if (_transportType.ToUpper() == "RABBITMQ")
            {
                return await _rabbitmqBus.GetSendEndpoint(address ?? _commandAddress);
            }

            return await _memoryBus.GetSendEndpoint(address ?? _commandAddress);
        }
    }
}
