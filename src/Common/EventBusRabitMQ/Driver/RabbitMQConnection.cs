using EventBusRabitMQ.Driver.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventBusRabitMQ.Driver
{
    public class RabbitMQConnection
        : IRabbitMQConnection
    {
        private readonly IConnectionFactory connectionFactory;
        private IConnection connection;
        private bool disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            if (!IsConnected)
                TryConnect();
        }

        public bool IsConnected
        {
            get
            {
                return connection != null && connection.IsOpen;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
                throw new InvalidOperationException("No RabbitMQ connected!!!");

            return connection.CreateModel();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                try
                {
                    connection.Dispose();
                    disposed = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool TryConnect()
        {
            try
            {
                connection = connectionFactory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {

                Thread.Sleep(4000);
                connection = connectionFactory.CreateConnection();
            }

            return IsConnected;
        }
    }
}
