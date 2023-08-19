using Application.Features.Pods.Commands.Create;
using Application.Features.Pods.Commands.Delete;
using Application.Features.Pods.Commands.Update;
using Application.Features.Pods.Queries.GetById;
using Application.Features.Pods.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PodsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePodCommand createPodCommand)
    {
        CreatedPodResponse response = await Mediator.Send(createPodCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePodCommand updatePodCommand)
    {
        UpdatedPodResponse response = await Mediator.Send(updatePodCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedPodResponse response = await Mediator.Send(new DeletePodCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdPodResponse response = await Mediator.Send(new GetByIdPodQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPodQuery getListPodQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPodListItemDto> response = await Mediator.Send(getListPodQuery);
        return Ok(response);
    }
}