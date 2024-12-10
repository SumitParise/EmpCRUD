using DemoRestAPI.DAL;
using DemoRestAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DemoRestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpsController : ControllerBase
	{
		private readonly ApplicationDbContext dbContext;


		// Constructor Injection
		public EmpsController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		// Get All Emp
		[HttpGet]
	public IActionResult GetAllEmps()
		{

			var allEmps = dbContext.Emps.ToList();

			return Ok(allEmps);
		}

		// Get Emp By Id

		[HttpGet]
		[Route("{id:Guid}")]

		public IActionResult GetEmpById(Guid id)
		{
			var Emp = dbContext.Emps.Find(id);

			if (Emp is null)
			{
				return NotFound();
			}
			return Ok(Emp);

		}

		// Add Emp
		[HttpPost]
		public IActionResult AddEmps(AddEmpDto addEmpDto)
		{
			var EmpEntity = new Employee()
			{
				Name = addEmpDto.Name,
				Email = addEmpDto.Email,
				Phone = addEmpDto.Phone,

			};

			dbContext.Add(EmpEntity);
			dbContext.SaveChanges();

			return Ok(EmpEntity);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public IActionResult updateEmp(Guid id, UpdateEmps updateEmpDto)
		{
			var Emp = dbContext.Emps.Find(id);

			if (Emp is null)
			{
				return NotFound();
			}

			Emp.Name = updateEmpDto.Name;
			dbContext.SaveChanges();
			return Ok(Emp);
		}

		[HttpDelete]
		[Route("{id:Guid}")]

		public IActionResult DeleteEmp(Guid id)
		{

			var Emp = dbContext.Emps.Find(id);

			if (Emp is null)
			{ return NotFound(); }

			dbContext.Emps.Remove(Emp);
			dbContext.SaveChanges();
			return Ok(Emp);
		}
	}
}
