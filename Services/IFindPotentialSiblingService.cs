using SchoolApi.Models;

namespace SchoolApi.Services;

public interface IFindPotentialSiblingService
{
  List<Student> GetStudentsWithMatchingLastName(Student student);
}
