
using Catalog.API.Products.GetProductByCategory;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, string Description, decimal Price, List<string> Category, string ImageFile);
    public record UpdateProductResponse(bool isSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (ISender sender, UpdateProductRequest request) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);

            })
                .WithName("UpdateProduct")
                .Produces<UpdateProductResponse>(200)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Updates Product")
                .WithDescription("Updates Product"); 
        }
    }
}
