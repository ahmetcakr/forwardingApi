using Application.Features.EBills.Commands.Create;
using Application.Features.EBills.Commands.Delete;
using Application.Features.EBills.Commands.Update;
using Application.Features.EBills.Queries.GetById;
using Application.Features.EBills.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EBillsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEBillCommand createEBillCommand)
    {
        CreatedEBillResponse response = await Mediator.Send(createEBillCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEBillCommand updateEBillCommand)
    {
        UpdatedEBillResponse response = await Mediator.Send(updateEBillCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEBillResponse response = await Mediator.Send(new DeleteEBillCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEBillResponse response = await Mediator.Send(new GetByIdEBillQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEBillQuery getListEBillQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEBillListItemDto> response = await Mediator.Send(getListEBillQuery);
        return Ok(response);
    }
}