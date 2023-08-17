using Application.Features.FirmTypes.Commands.Create;
using Application.Features.FirmTypes.Commands.Delete;
using Application.Features.FirmTypes.Commands.Update;
using Application.Features.FirmTypes.Queries.GetById;
using Application.Features.FirmTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FirmTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFirmTypeCommand createFirmTypeCommand)
    {
        CreatedFirmTypeResponse response = await Mediator.Send(createFirmTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFirmTypeCommand updateFirmTypeCommand)
    {
        UpdatedFirmTypeResponse response = await Mediator.Send(updateFirmTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedFirmTypeResponse response = await Mediator.Send(new DeleteFirmTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdFirmTypeResponse response = await Mediator.Send(new GetByIdFirmTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFirmTypeQuery getListFirmTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFirmTypeListItemDto> response = await Mediator.Send(getListFirmTypeQuery);
        return Ok(response);
    }
}