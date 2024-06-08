using MassTransit;
using Registration.Application.RabbitMQService.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.RabbitMQService.Producers.GovernateCountNotification
{
    public class GovernateCountNotificationService : IGovernateCountNotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public GovernateCountNotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task SentNotification(Guid governateId)
        {
            await _publishEndpoint.Publish(new GovernateCountNotificationRecord(governateId));
        }
    }
}
