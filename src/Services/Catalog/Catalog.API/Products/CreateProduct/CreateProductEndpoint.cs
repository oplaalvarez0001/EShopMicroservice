

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductRequest(string Name, List<String> Category, string ImageFile, string Description, decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
            {

                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);



            })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(201)
                .WithSummary("Creates a new product")
                .WithDescription("Creates a new product in the catalog");
        }
    }
}
