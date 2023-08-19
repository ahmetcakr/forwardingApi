using Application.Features.FreeDays.Commands.Create;
using Application.Features.FreeDays.Commands.Delete;
using Application.Features.FreeDays.Commands.Update;
using Application.Features.FreeDays.Queries.GetById;
using Application.Features.FreeDays.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FreeDaysController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFreeDayCommand createFreeDayCommand)
    {
        CreatedFreeDayResponse response = await Mediator.Send(createFreeDayCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFreeDayCommand updateFreeDayCommand)
    {
        UpdatedFreeDayResponse response = await Mediator.Send(updateFreeDayCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedFreeDayResponse response = await Mediator.Send(new DeleteFreeDayCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdFreeDayResponse response = await Mediator.Send(new GetByIdFreeDayQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFreeDayQuery getListFreeDayQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFreeDayListItemDto> response = await Mediator.Send(getListFreeDayQuery);
        return Ok(response);
    }
}