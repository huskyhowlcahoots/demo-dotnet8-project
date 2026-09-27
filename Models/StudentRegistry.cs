namespace SchoolApi.Models;

public class StudentRegistry
{
  public static List<Student> Students =
  [
    new Student(2021, "Aarav", "Mooniyen", 5),
    new Student(2023, "Vihaan", "Mooniyen", 3),
    new Student(2022, "John", "Black", 4)
  ];

  public StudentRegistry(List<Student> list)
  {
    Students = list;
  }
}
