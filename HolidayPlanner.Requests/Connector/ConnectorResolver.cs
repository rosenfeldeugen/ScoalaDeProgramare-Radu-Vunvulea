using System;
using System.Collections.Generic;

namespace HolidayPlanner.Requests
{
    //CR: not really needed. We have to send an email. 
    //CR: This class is an assumption
    public class ConnectorResolver : IConnectorResolver
    {
        private readonly Dictionary<Type, Func<object>> connectorMapping;

        public ConnectorResolver()
        {
            connectorMapping = new Dictionary<Type, Func<object>>
            {
                {typeof (Email), () => new EmailConnector()}
            };
        }

        public IConnector<TMessage> Resolve<TMessage>()
            where TMessage : class
        {
            IConnector<TMessage> requestedConnector = (IConnector<TMessage>) connectorMapping[typeof (TMessage)].Invoke();

            return requestedConnector;
        }
    }
}