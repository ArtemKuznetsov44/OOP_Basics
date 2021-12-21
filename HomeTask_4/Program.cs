using System;

namespace HomeTask_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Building ourBuilding = new();
            Console.WriteLine("Номер первого здания: " + ourBuilding.GetBuildingNumber());
            Building ourBuilding1 = new();
            Console.WriteLine("Номер второго здания: " + ourBuilding1.GetBuildingNumber());
            Console.WriteLine("========================================");
            Console.WriteLine("Заполнение полей класса с помощь методов и считывание значений:");
            ourBuilding.SetBuildingHeight(25);
            ourBuilding.SetNumberOfApartments(40);
            ourBuilding.SetNumberOfEntrances(2);
            ourBuilding.SetNumberOfStoreys(5);
            ourBuilding.SetBuildingNumber(113);
            Console.WriteLine("Номер: " + ourBuilding.GetBuildingNumber());
            Console.WriteLine("Высота здания(м): " + ourBuilding.GetBuildingHeight());
            Console.WriteLine("Кол-во квартир: " + ourBuilding.GetNumberOfApartments());
            Console.WriteLine("Кол-во подъездов: " + ourBuilding.GetNumberOfEntrances());
            Console.WriteLine("Кол-во этажей: " + ourBuilding.GetNumberOfStoreys());
            Console.WriteLine("========================================");
            Console.WriteLine("Вычислительные методы:");
            Console.WriteLine("Кол-во квартир в подъезде: " + ourBuilding.GetNumberOfApartmentsInEntance());
            Console.WriteLine("Высота одного этажа(м): " + ourBuilding.GetFloorHeight());
            Console.WriteLine("Кол-во квартир на этаже: " + ourBuilding.GetNumberOfApartmentsOnFloor());
            Console.WriteLine("========================================");
            Console.Read(); 
        }
    }
}
