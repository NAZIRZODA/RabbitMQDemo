using Domain;
using MassTransit;

namespace RMQ_MT_Consumer;

public class OrderConsumer : IConsumer<Order>
{
    public async Task Consume(ConsumeContext<Order> context)
    {
        await Console.Out.WriteLineAsync(
            $"Consumed: {context.Message.Id}, {context.Message.OrderItems}, {context.Message.TotalAmount}");
    }
}