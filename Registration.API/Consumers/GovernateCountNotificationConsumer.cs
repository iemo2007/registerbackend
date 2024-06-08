using MassTransit;
using Registration.Application.Features.GovernateCountFeatures.Commands.IncreaseGovernateCount;
using Registration.Application.RabbitMQService.Records;

namespace Registration.API.Consumers
{
    public class GovernateCountNotificationConsumer : IConsumer<GovernateCountNotificationRecord>
    {
        private readonly MediatR.IMediator _mediator;

        public GovernateCountNotificationConsumer(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<GovernateCountNotificationRecord> context)
        {
            await _mediator.Send(new IncreaseGovernateCountCommand(context.Message.governateId));
        }
    }
}
