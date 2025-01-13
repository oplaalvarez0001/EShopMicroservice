namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<String> Category, string ImageFile, string Description, decimal Price)
    : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);


    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create a product

            //create Product Entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Description = command.Description,
                Price = command.Price
            };

            //save to db
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);


            //return CreateProductResult result
            return new CreateProductResult(product.Id);


            //throw new NotImplementedException();
        }
    }
}
