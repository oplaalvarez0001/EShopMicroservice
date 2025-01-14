
using MediatR;

namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdRequest();
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProductById")
                .Produces<GetProductByIdResponse>(200)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Gets product by id")
                .WithDescription("Gets product by id"); ;
        }
    }   
}
