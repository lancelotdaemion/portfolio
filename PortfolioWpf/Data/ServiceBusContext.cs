﻿namespace PortfolioWpf.Data
{
    public class ServiceBusContext
    {
        public string ConnectionString => @"Endpoint=sb://lancelot.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=EJsX17fQjeMqtZSdAqYRgcX63viu7mWrD+ASbN/a5nA=";
        public string Namespace => "lancelot";
        public string QueueName => "portfolio";
    }
}
