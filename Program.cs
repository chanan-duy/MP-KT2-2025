namespace MP_KT2_2025;

internal static class Program
{
    private static int ReadUntilInt(Func<int, bool>? validator = null, string? messageWhenValidatorFails = null)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var num))
            {
                Console.WriteLine("Вы ввели неправильное число.");
            }
            else if (validator != null && !validator(num))
            {
                Console.WriteLine(messageWhenValidatorFails ?? "Условие нарушено.");
            }
            else
            {
                return num;
            }
        }
    }

    private static void PrintStudentsOut(Student[] students)
    {
        for (var i = 0; i < students.Length; i++)
        {
            var student = students[i];
            Console.WriteLine($"{i}. {student}");
        }
    }

    private static void CompareStudents(Student student1, Student student2)
    {
        Console.WriteLine($"student1 == student2 ? {student1 == student2}");
        Console.WriteLine($"student1 != student2 ? {student1 != student2}");
        Console.WriteLine(student1 ? "student1 is true" : "student1 is false");
        Console.WriteLine(student2 ? "student2 is true" : "student2 is false");
    }

    private static bool CompareLoop(Student[] students)
    {
        PrintStudentsOut(students);

        Console.WriteLine("Введите индекс студента 1:");
        var studentIndex1 = ReadUntilInt(num => num >= 0 && num < students.Length, "Число выходит за рамки массива.");
        var student1 = students[studentIndex1];

        Console.WriteLine("Введите индекс студента 2, с которым сравним:");
        var studentIndex2 = ReadUntilInt(num => num >= 0 && num < students.Length, "Число выходит за рамки массива.");
        var student2 = students[studentIndex2];

        CompareStudents(student1, student2);

        Console.WriteLine("Продолжим? (quit - чтобы создать новый массив)");
        if (Console.ReadLine()?.Trim().ToLower() == "quit")
        {
            return false;
        }

        return true;
    }

    private static bool MainLoop()
    {
        Console.WriteLine("\nСколько студентов создать:");
        var studentsCount = ReadUntilInt(num => num > 0, "> 0");

        var students = new Student[studentsCount];
        for (var i = 0; i < students.Length; i++)
        {
            students[i] = Student.CreateRandom();
        }

        while (CompareLoop(students))
        {
        }

        return true;
    }

    private static void Main(string[] _)
    {
        while (MainLoop())
        {
        }
    }
}
