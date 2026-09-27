using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Services;

namespace SchoolApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
  // A random service we need - SOLID says implementations are interchangeable, so inject interfaces, don't rely on implementations
  public IFindPotentialSiblingService _siblingService;

  // inject that service into the constructor of the controller AND register against DI container in Program.cs (there you register it's interface and flavour)
  // The code in this controller does not know which flavour of implementation to use, that's why Dependency Registration must be done in Program.cs, defining that.
  // Of course, if setup as a singleton or scoped lifespan, it will be more effective than creating that dependency each time the code reaches this class/controller.
  public StudentController(IFindPotentialSiblingService siblingService)
  {
    _siblingService = siblingService;
  }

  [HttpGet("students")]
  public ActionResult<Student> GetStudents()
  {
    return Ok(StudentRegistry.Students);
  }

  [HttpGet("potentialSiblings")]
  public ActionResult<Student> GetPotentialSiblings()
  {
    // Aarav Mooniyen
    Student studentToSearchSiblingsFor = StudentRegistry.Students[0];

    var res = _siblingService.GetStudentsWithMatchingLastName(studentToSearchSiblingsFor);

    return Ok(res);
  }
}
