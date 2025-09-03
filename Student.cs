namespace MP_KT2_2025;

public class Student
{
    public bool IsActive;
    public char Grade;
    public int Age;

    public Student(bool isActive, char grade, int age)
    {
        IsActive = isActive;
        Grade = grade;
        Age = age;
    }

    public static Student CreateRandom()
    {
        char[] grades = ['a', 'b', 'c'];

        var grade = Random.Shared.GetItems(grades, 1).First();
        var age = Random.Shared.Next(17, 19);
        var isActive = Random.Shared.NextDouble() >= .5;

        var obj = new Student(isActive, grade, age);

        return obj;
    }

    public static bool operator ==(Student obj, Student other)
    {
        if (obj.IsActive == other.IsActive && obj.Grade == other.Grade && obj.Age == other.Age)
        {
            return true;
        }

        return false;
    }

    public static bool operator !=(Student obj, Student other)
    {
        if (obj.IsActive != other.IsActive || obj.Grade != other.Grade || obj.Age != other.Age)
        {
            return true;
        }

        return false;
    }

    public static bool operator true(Student obj)
    {
        return obj.IsActive;
    }

    public static bool operator false(Student obj)
    {
        return !obj.IsActive;
    }

    public override string ToString()
    {
        return $"isActive: {IsActive}\tgrade: {Grade}\tage: {Age}";
    }
}
