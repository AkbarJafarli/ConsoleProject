using ConsoleProject.Exceptions;
using ConsoleProject.Models;

namespace ConsoleProject.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            Array.Resize(ref DB.Medicines, DB.Medicines.Length + 1);
            DB.Medicines[DB.Medicines.Length - 1] = medicine;
        }
        public Medicine[] GetAllMedicines()
        {
            return DB.Medicines;
        }
        public Medicine GetMedicineById(int id)
        {
            foreach (var item in DB.Medicines)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new NotFoundException("Id not found");
        }
        public Medicine GetMedicineByName(string name)
        {
            foreach (var item in DB.Medicines)
            {
                if (item.Name == name)
                    return item;
            }
            throw new NotFoundException("Name not found");
        }
        public void GetMedicineByCategory(int categoryId)
        {
            foreach (var item in DB.Medicines)
            {
                if (item.CategoryId == categoryId)
                {
                    Console.WriteLine($"Id: {item.Id} - Name:{item.Name} - CreatedDate: {item.CreatedDate} - Price: {item.Price}");
                }
            }
            throw new NotFoundException("Id not found");
        }
        public void RemoveMedicine(int id)
        {
            for (int i = 0; i < DB.Medicines.Length; i++)
            {
                var Medicinies = DB.Medicines[i];
                if (Medicinies.Id == id)
                {
                    for (int j = i; j < DB.Medicines.Length - 1; j++)
                    {
                        DB.Medicines[j] = DB.Medicines[j + 1];
                    }
                    Array.Resize(ref DB.Medicines, DB.Medicines.Length - 1);
                    Console.WriteLine("Medicines removed");
                    return;
                }
            }
            throw new NotFoundException($"{id} this id is not found");
        }
        public void UpdateMedicine(int id, Medicine medicine)
        {

            foreach (var medicine1 in DB.Medicines)
            {
                if (medicine1.Id == id)
                {
                    medicine1.Name = medicine.Name;
                    medicine1.Price = medicine.Price;
                    medicine1.CategoryId = medicine.CategoryId;
                    Console.WriteLine("Medicine updated");
                    return;
                }

            }
            throw new NotFoundException($"{id} this id is not found");

        }

    }
}
