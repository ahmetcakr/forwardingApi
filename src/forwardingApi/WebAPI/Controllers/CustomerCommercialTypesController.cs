using Application.Features.CustomerCommercialTypes.Commands.Create;
using Application.Features.CustomerCommercialTypes.Commands.Delete;
using Application.Features.CustomerCommercialTypes.Commands.Update;
using Application.Features.CustomerCommercialTypes.Queries.GetById;
using Application.Features.CustomerCommercialTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCommercialTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommercialTypeCommand createCustomerCommercialTypeCommand)
    {
        CreatedCustomerCommercialTypeResponse response = await Mediator.Send(createCustomerCommercialTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommercialTypeCommand updateCustomerCommercialTypeCommand)
    {
        UpdatedCustomerCommercialTypeResponse response = await Mediator.Send(updateCustomerCommercialTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCommercialTypeResponse response = await Mediator.Send(new DeleteCustomerCommercialTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCommercialTypeResponse response = await Mediator.Send(new GetByIdCustomerCommercialTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCommercialTypeQuery getListCustomerCommercialTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCommercialTypeListItemDto> response = await Mediator.Send(getListCustomerCommercialTypeQuery);
        return Ok(response);
    }
}