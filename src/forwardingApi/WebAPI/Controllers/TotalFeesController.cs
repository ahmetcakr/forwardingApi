using Application.Features.TotalFees.Commands.Create;
using Application.Features.TotalFees.Commands.Delete;
using Application.Features.TotalFees.Commands.Update;
using Application.Features.TotalFees.Queries.GetById;
using Application.Features.TotalFees.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TotalFeesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTotalFeeCommand createTotalFeeCommand)
    {
        CreatedTotalFeeResponse response = await Mediator.Send(createTotalFeeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTotalFeeCommand updateTotalFeeCommand)
    {
        UpdatedTotalFeeResponse response = await Mediator.Send(updateTotalFeeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTotalFeeResponse response = await Mediator.Send(new DeleteTotalFeeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTotalFeeResponse response = await Mediator.Send(new GetByIdTotalFeeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTotalFeeQuery getListTotalFeeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTotalFeeListItemDto> response = await Mediator.Send(getListTotalFeeQuery);
        return Ok(response);
    }
}