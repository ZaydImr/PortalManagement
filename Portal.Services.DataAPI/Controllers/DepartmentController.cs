using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Services.DataAPI.Data;
using Portal.Services.DataAPI.Model;
using Portal.Services.DataAPI.Model.ViewModel;

namespace Portal.Services.DataAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public DepartmentController(AppDbContext db, IMapper mapper, ILogger<DepartmentController> logger)
    {
        _db = db;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation("Get Departments");
            IEnumerable<DepartmentVM> objList = await _db.Department
                .Select(dep => _mapper.Map<DepartmentVM>(dep))
                .ToListAsync();
            return Ok(objList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        try
        {
            _logger.LogInformation("Get Department");
            Department? obj = await _db.Department.FirstOrDefaultAsync( dep => dep.DepartmentID == Id);

            if (obj == null)
            {
                return NotFound("The department doesn't exists!");
            }

            return Ok(_mapper.Map<DepartmentVM>(obj));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.StackTrace);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(DepartmentVM department)
    {
        try
        {
            _logger.LogInformation("Add Department");
            Department dep = (await _db.Department.AddAsync(_mapper.Map<Department>(department))).Entity;
            await _db.SaveChangesAsync();

            return Ok(_mapper.Map<DepartmentVM>(dep));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.StackTrace);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(DepartmentVM department)
    {
        try
        {
            _logger.LogInformation("Add Department");
            Department dep = _db.Department.Update(_mapper.Map<Department>(department)).Entity;
            await _db.SaveChangesAsync();

            return Ok(_mapper.Map<DepartmentVM>(dep));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.StackTrace);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        {
            Department department = await _db.Department.FirstAsync(dep => dep.DepartmentID == Id);
            _db.Department.Remove(department);
            await _db.SaveChangesAsync();

            return Ok("Deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.StackTrace);
            return BadRequest(ex.Message);
        }
    }
}
