using Application.Features.CustomerFirmTypes.Commands.Create;
using Application.Features.CustomerFirmTypes.Commands.Delete;
using Application.Features.CustomerFirmTypes.Commands.Update;
using Application.Features.CustomerFirmTypes.Queries.GetById;
using Application.Features.CustomerFirmTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerFirmTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerFirmTypeCommand createCustomerFirmTypeCommand)
    {
        CreatedCustomerFirmTypeResponse response = await Mediator.Send(createCustomerFirmTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerFirmTypeCommand updateCustomerFirmTypeCommand)
    {
        UpdatedCustomerFirmTypeResponse response = await Mediator.Send(updateCustomerFirmTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerFirmTypeResponse response = await Mediator.Send(new DeleteCustomerFirmTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerFirmTypeResponse response = await Mediator.Send(new GetByIdCustomerFirmTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerFirmTypeQuery getListCustomerFirmTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerFirmTypeListItemDto> response = await Mediator.Send(getListCustomerFirmTypeQuery);
        return Ok(response);
    }
}