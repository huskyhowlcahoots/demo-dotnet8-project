using SchoolApi.Models;

namespace SchoolApi.Services;

public class FindPotentialSiblingService : IFindPotentialSiblingService
{
  public List<Student> GetStudentsWithMatchingLastName(Student student)
  {
    List<Student> result = new();

    foreach (var kid in StudentRegistry.Students)
    {
      if (kid.LastName == student.LastName)
        result.Add(kid);
    }

    return result;
  }
}
