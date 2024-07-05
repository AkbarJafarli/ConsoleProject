using ConsoleProject.Exceptions;
using ConsoleProject.Models;
using ConsoleProject.Services;
using ConsoleProject.Utilities;


UserService userService = new UserService();
User activeUser = new("Admin", "admin@gmail.com", "Admin123");
MedicineService medicineService = new MedicineService();
userService.AddUser(activeUser);
Console.WriteLine("----------------------------------CODE HOSPITAL----------------------------------");
restart2:
while (true)
{
    Console.WriteLine("1.Register \n2.Login \n3.Remove user \n4.Exit");
    Console.WriteLine("");
    Console.Write("Select:");
    int selectChoice = int.Parse(Console.ReadLine());
    if (selectChoice == 1)
    {
        Console.Write("Enter Fullname:");
        string fullname = Console.ReadLine();
        Console.Write("Enter Email:");
        string email = Console.ReadLine();
        while (true)
        {
            if (email.EmailChecker() == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid email...");
                Console.Write("Enter Email:");
                email = Console.ReadLine();
            }
        }
        Console.Write("Enter Password:");
        string password = Console.ReadLine();
        while (true)
        {
            if (password.PasswordChecker() == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid password...");
                Console.Write("Enter Password:");
                password = Console.ReadLine();
            }
        }
        User User = new(fullname, email, password);
        userService.AddUser(User);
        Console.WriteLine("");
    }
    else if (selectChoice == 2)
    {
        Console.Write("Enter email:");
        string loginEmail = Console.ReadLine();
        Console.Write("Enter password:");
        string loginPassword = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            activeUser = userService.Login(loginEmail, loginPassword);
            Console.WriteLine($"Welcome,{activeUser.FullName}");
            break;
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else if (selectChoice == 3)
    {
        Console.Write("Enter Email:");
        string deleteEmail = Console.ReadLine();
        Console.Write("Enter Password:");
        string deletePassword = Console.ReadLine();
        try
        {
            userService.RemoveUser(deleteEmail);
            Console.WriteLine("User succesfully removed");
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            goto restart2;
        }
    }
    else if (selectChoice == 4)
    {
        return;
    }
    else
    {
        Console.WriteLine("Please enter correct choice...");
    }
}



Console.WriteLine("");
Console.WriteLine("___Welcome to the Code Hospital___ ");
Console.WriteLine("");
restart:
Console.WriteLine("1.Create a new Category");
Console.WriteLine("2.Create a new Medicine");
Console.WriteLine("3.Remove a Medicine");
Console.WriteLine("4.List all Medicines");
Console.WriteLine("5.Update a Medicine");
Console.WriteLine("6.Find Medicine by Id");
Console.WriteLine("7.Find Medicine by Name");
Console.WriteLine("8.Find Medicine by Category");
Console.WriteLine("9.View Medicines");
Console.WriteLine("0.Logout");
Console.WriteLine("");
Console.Write("Select:");

int choice = int.Parse(Console.ReadLine());
if (choice == 1)
{
    Console.Write("Enter category name:");
    string categoryName = Console.ReadLine();
    Category category = new Category(categoryName);
    UserService userService1 = new UserService();
    userService1.CreateCategory(category);
    Console.WriteLine("");
    goto restart;
}
else if (choice == 2)
{
    Console.Write("Enter Medicine name:");
    string medicineName = Console.ReadLine();
    Console.Write("Enter Medicine price:");
    int medicinePrice = int.Parse(Console.ReadLine());
    Console.Write("Enter Category id:");
    int categoryId = int.Parse(Console.ReadLine());
    Medicine medicine = new Medicine(medicineName, medicinePrice, categoryId, activeUser.Id);
    medicineService = new MedicineService();
    medicineService.CreateMedicine(medicine);
    Console.WriteLine("");
    goto restart;
}
else if (choice == 3)
{
    medicineService = new MedicineService();
    Console.WriteLine("Enter Medicine id:");
    int id = int.Parse(Console.ReadLine());
    medicineService.RemoveMedicine(id);
    Console.WriteLine("");
    goto restart;
}
else if (choice == 4)
{
    medicineService = new MedicineService();
    medicineService.GetAllMedicines();
    Console.WriteLine("");
    goto restart;
}
else if (choice == 5)
{
    medicineService = new MedicineService();
    Console.WriteLine("Enter id:");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Enter Medicine name:");
    string medicineName = Console.ReadLine();
    Console.Write("Enter Medicine price: ");
    int medicinePrice = int.Parse(Console.ReadLine());
    Console.Write("Enter category id:");
    int categoryId = int.Parse(Console.ReadLine());
    Medicine medicine = new Medicine(medicineName, medicinePrice, categoryId, activeUser.Id);
    medicineService.UpdateMedicine(id, medicine);
    Console.WriteLine("");
    goto restart;
}
else if (choice == 6)
{
    medicineService = new MedicineService();
    Console.Write("Enter id:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine(medicineService.GetMedicineById(id));
    Console.WriteLine("");
    goto restart;
}
else if (choice == 7)
{
    medicineService = new MedicineService();
    Console.Write("Enter Medicine name:");
    string medicineName = Console.ReadLine();
    try
    {
        medicineService.GetMedicineByName(medicineName);
        Console.WriteLine("");
        goto restart;
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
else if (choice == 8)
{
    medicineService = new MedicineService();
    Console.Write("Enter id:");
    int categoryId = int.Parse(Console.ReadLine());
    medicineService.GetMedicineByCategory(categoryId);
    Console.WriteLine("");
    goto restart;
}
else if (choice == 9)
{
    medicineService.GetAllMedicines();
    Console.WriteLine("");
    goto restart;
}
else if (choice == 0)
{
    goto restart2;
}
else
{
    Console.WriteLine("Pleace enter correct choice...");
}





