using Microsoft.AspNetCore.Mvc;
using RubiksWord.Core.UseCases;
using System.Threading.Tasks;
using AutoMapper;
using RubiksWord.API.DTO;
using RubiksWord.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading;
using System;

namespace RubiksWord.API.Controllers;

[Route("api/cube")]
public class CubeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly CubeUseCase _cubeCore;

    public CubeController(IMapper mapper, CubeUseCase cubeCore)
    {
        _mapper = mapper;
        _cubeCore = cubeCore;
    }

    [HttpGet("{name}")]
    public async Task<CubeDTO> GetByName([FromRoute]string name = "test")
    {
        Cube rawResult = await _cubeCore.GetByName(name);
        CubeDTO mappedResult = _mapper.Map<CubeDTO>(rawResult);
        return mappedResult;
    }

    [HttpGet("{name}/ws/state")]
    public async Task State([FromRoute] string name = "test")
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private static async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }
}
