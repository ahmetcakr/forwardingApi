using Application.Features.CustomerGroups.Commands.Create;
using Application.Features.CustomerGroups.Commands.Delete;
using Application.Features.CustomerGroups.Commands.Update;
using Application.Features.CustomerGroups.Queries.GetById;
using Application.Features.CustomerGroups.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerGroupsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerGroupCommand createCustomerGroupCommand)
    {
        CreatedCustomerGroupResponse response = await Mediator.Send(createCustomerGroupCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerGroupCommand updateCustomerGroupCommand)
    {
        UpdatedCustomerGroupResponse response = await Mediator.Send(updateCustomerGroupCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerGroupResponse response = await Mediator.Send(new DeleteCustomerGroupCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerGroupResponse response = await Mediator.Send(new GetByIdCustomerGroupQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerGroupQuery getListCustomerGroupQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerGroupListItemDto> response = await Mediator.Send(getListCustomerGroupQuery);
        return Ok(response);
    }
}