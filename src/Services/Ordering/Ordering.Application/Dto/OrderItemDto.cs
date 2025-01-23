namespace Ordering.Application.Dto
{
    public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);
}
