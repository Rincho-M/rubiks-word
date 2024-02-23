using Microsoft.AspNetCore.Mvc;
using RubiksWord.Domain.UseCases;
using System.Threading.Tasks;
using AutoMapper;
using RubiksWord.API.DTO;
using RubiksWord.Domain.Entities;

namespace RubiksWord.API.Controllers;

[Route("api/cube")]
public class CubeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly CubeUseCases _cubeUseCases;

    public CubeController(IMapper mapper, CubeUseCases cubeCore)
    {
        _mapper = mapper;
        _cubeUseCases = cubeCore;
    }

    [HttpGet("{name}")]
    public async Task<CubeDTO> GetByName([FromRoute]string name = "test")
    {
        Cube rawResult = await _cubeUseCases.GetByName(name);
        CubeDTO result = _mapper.Map<CubeDTO>(rawResult);
        return result;
    }

    [HttpGet("{name}/face")]
    public async Task<FaceDTO> GetFaceByCubeName([FromRoute]string name = "test")
    {
        Cube rawResult = await _cubeUseCases.GetByName(name);
        CubeDTO cubeResult = _mapper.Map<CubeDTO>(rawResult);
        FaceDTO result = _mapper.Map<FaceDTO>(cubeResult);
        return result;
    }

    [HttpPost]
    public async Task<CubeDTO> Create([FromBody]CubeDTO rawCubeData)
    {
        Cube cubeData = _mapper.Map<Cube>(rawCubeData);
        Cube rawResult = await _cubeUseCases.Create(cubeData);
        CubeDTO result = _mapper.Map<CubeDTO>(rawResult);
        return result;
    }

}
