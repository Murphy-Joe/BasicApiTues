using AutoMapper;
using BasicApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AutoMapper.QueryableExtensions;

namespace BasicApi.Controllers;

public class AgentsController : ControllerBase
{

    private readonly BasicDataContext _context;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _config;

    public AgentsController(BasicDataContext context, IMapper mapper, MapperConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    [HttpPost("/agents")]
    public async Task<ActionResult<AgentResponseItem>> AddAgent([FromBody] AgentCreateRequest request)
    {
        // Validate it - if bad, send a 400
        if(!ModelState.IsValid) { return BadRequest(); }
        // Add it to the database.
            // Map an Agent from our AgentCreateRequest
            // Save the changes.
        // Return a 201, with a Location header with url, and a copy of the thing they would get if they did a
        //   GET request to that location header.
        return Ok(request);
    }

    [HttpGet("/agents")]
    // /agents?state=UT
    public async Task<ActionResult<GetAgentsResponse>> GetAllAgents([FromQuery] string state = "all")
    {

        var response = new GetAgentsResponse();
        response.StateFilter = state;

        var query = _context.Agents!.Where(a => a.Retired == false);

        if (state != "all")
        {
            query = query.Where(a => a.State == state);
        }


        response.Agents = await query
             .ProjectTo<AgentResponseItem>(_config)
             .ToListAsync(); // Non-Deferred Operator (PROVE IT! Do IT)
        return Ok(response);


    }

    [HttpGet("/agents/{agentId:int}")]
    public async Task<ActionResult<AgentResponseItem>> FindAgent(int agentId)
    {

        var agent = await _context.Agents!
             .Where(a => a.Retired == false && a.Id == agentId)
             .ProjectTo<AgentResponseItem>(_config)
             .SingleOrDefaultAsync();

        if (agent == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(agent);
        }
    }
}


public class GetAgentsResponse
{
    [Required]
    public List<AgentResponseItem> Agents { get; set; } = new List<AgentResponseItem>();

    public string? StateFilter { get; set; }
}

public class AgentResponseItem
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }

    public string? State { get; set; }
}



public class AgentCreateRequest
{
    [Required]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    public string LastName { get; set; }= String.Empty;
    [Required]
    public string Phone { get; set; } = String.Empty;
    public string? Email { get; set; }

    [Required, MaxLength(2), MinLength(2)]
    public string StateCode { get; set; } = string.Empty;
}
