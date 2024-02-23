using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using RubiksWord.API.DTO;
using RubiksWord.Domain.DataTypes;
using RubiksWord.Domain.Entities;
using RubiksWord.Domain.UseCases;
using System;
using System.Threading.Tasks;

namespace RubiksWord.API.Hubs;

public class CubeHub : Hub<ICubeHub>
{
    private readonly IMapper _mapper;
    private readonly CubeUseCases _cubeUseCases;

    public CubeHub(IMapper mapper, CubeUseCases cubeCore)
    {
        _mapper = mapper;
        _cubeUseCases = cubeCore;
    }

    public async Task RotateFull(RotateFullDTO request)
    {
        Cube rawResult = await _cubeUseCases.RotateFull(request.CubeId, request.Axis, request.Direction);
        CubeDTO result = _mapper.Map<CubeDTO>(rawResult);
        await Clients.All.SendUpdated(result);
    }
}

public interface ICubeHub
{
    Task HandleWrittenLetter(string message);
    Task SendUpdated(CubeDTO cube);
}
