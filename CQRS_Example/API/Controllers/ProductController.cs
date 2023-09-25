using CQRS_Example.Application.Commands.ProductCommands;
using CQRS_Example.Application.Notifications;
using CQRS_Example.Application.Queries;
using CQRS_Example.Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Example.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
            await _mediator.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product updatedProduct)
        {
            // Fetch the existing product
            var existingProduct = await _mediator.Send(new GetProductByIdQuery(updatedProduct.Id));

            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the product
            var updated = await _mediator.Send(new UpdateProductCommand(updatedProduct));

            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(int Id)
        {
            var isSuccess = await _mediator.Send(new DeleteProductCommand(Id));
            return CreatedAtRoute("DeleteProductById", new { success= isSuccess });
        }
    }
}
