using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.RabbitMQService.Producers.GovernateCountNotification
{
    public interface IGovernateCountNotificationService
    {
        Task SentNotification(Guid governateId);
    }
}
