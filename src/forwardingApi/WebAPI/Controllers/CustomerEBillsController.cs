using Application.Features.CustomerEBills.Commands.Create;
using Application.Features.CustomerEBills.Commands.Delete;
using Application.Features.CustomerEBills.Commands.Update;
using Application.Features.CustomerEBills.Queries.GetById;
using Application.Features.CustomerEBills.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerEBillsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerEBillCommand createCustomerEBillCommand)
    {
        CreatedCustomerEBillResponse response = await Mediator.Send(createCustomerEBillCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerEBillCommand updateCustomerEBillCommand)
    {
        UpdatedCustomerEBillResponse response = await Mediator.Send(updateCustomerEBillCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerEBillResponse response = await Mediator.Send(new DeleteCustomerEBillCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerEBillResponse response = await Mediator.Send(new GetByIdCustomerEBillQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerEBillQuery getListCustomerEBillQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerEBillListItemDto> response = await Mediator.Send(getListCustomerEBillQuery);
        return Ok(response);
    }
}