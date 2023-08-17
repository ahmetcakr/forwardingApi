using Application.Features.CustomerCommercialDetails.Commands.Create;
using Application.Features.CustomerCommercialDetails.Commands.Delete;
using Application.Features.CustomerCommercialDetails.Commands.Update;
using Application.Features.CustomerCommercialDetails.Queries.GetById;
using Application.Features.CustomerCommercialDetails.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCommercialDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommercialDetailCommand createCustomerCommercialDetailCommand)
    {
        CreatedCustomerCommercialDetailResponse response = await Mediator.Send(createCustomerCommercialDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommercialDetailCommand updateCustomerCommercialDetailCommand)
    {
        UpdatedCustomerCommercialDetailResponse response = await Mediator.Send(updateCustomerCommercialDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCommercialDetailResponse response = await Mediator.Send(new DeleteCustomerCommercialDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCommercialDetailResponse response = await Mediator.Send(new GetByIdCustomerCommercialDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCommercialDetailQuery getListCustomerCommercialDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCommercialDetailListItemDto> response = await Mediator.Send(getListCustomerCommercialDetailQuery);
        return Ok(response);
    }
}