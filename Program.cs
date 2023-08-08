

using SRP_Employee;
using SRP_Employee.Data;

int secim = 0;
Message.Greeting();
while (true)
{
    foreach (Menu m in MenuData.MenuList)
        Console.WriteLine($"{m.Id}. {m.Name}");
    Console.Write("Lütfen seçim yapınız : ");
    try
    {
        secim=int.Parse( Console.ReadLine() );
        switch (secim)
        {
            case 1:
                foreach (Employee e in EmployeeData.GetEmployees())
                    Console.WriteLine(e);
                break;
            case 2:
                Employee employee = EmployeeData.AddEmployee();
                break;
        }
    }
    catch (Exception ex) { 
        Console.WriteLine(ex.Message); 
    }
}