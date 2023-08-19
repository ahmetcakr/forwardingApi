using Application.Features.Demurrages.Commands.Create;
using Application.Features.Demurrages.Commands.Delete;
using Application.Features.Demurrages.Commands.Update;
using Application.Features.Demurrages.Queries.GetById;
using Application.Features.Demurrages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DemurragesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDemurrageCommand createDemurrageCommand)
    {
        CreatedDemurrageResponse response = await Mediator.Send(createDemurrageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDemurrageCommand updateDemurrageCommand)
    {
        UpdatedDemurrageResponse response = await Mediator.Send(updateDemurrageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedDemurrageResponse response = await Mediator.Send(new DeleteDemurrageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdDemurrageResponse response = await Mediator.Send(new GetByIdDemurrageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDemurrageQuery getListDemurrageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDemurrageListItemDto> response = await Mediator.Send(getListDemurrageQuery);
        return Ok(response);
    }
}