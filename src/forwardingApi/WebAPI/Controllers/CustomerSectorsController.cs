using Application.Features.CustomerSectors.Commands.Create;
using Application.Features.CustomerSectors.Commands.Delete;
using Application.Features.CustomerSectors.Commands.Update;
using Application.Features.CustomerSectors.Queries.GetById;
using Application.Features.CustomerSectors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerSectorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerSectorCommand createCustomerSectorCommand)
    {
        CreatedCustomerSectorResponse response = await Mediator.Send(createCustomerSectorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerSectorCommand updateCustomerSectorCommand)
    {
        UpdatedCustomerSectorResponse response = await Mediator.Send(updateCustomerSectorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerSectorResponse response = await Mediator.Send(new DeleteCustomerSectorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerSectorResponse response = await Mediator.Send(new GetByIdCustomerSectorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerSectorQuery getListCustomerSectorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerSectorListItemDto> response = await Mediator.Send(getListCustomerSectorQuery);
        return Ok(response);
    }
}