using System;
using System.Collections.Generic;

// Абстрактний клас Vehicle
public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move(string startPoint, string endPoint);
}

// Клас Car
public class Car : Vehicle
{
    public Car()
    {
        Speed = 100;
        Capacity = 4;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Автомобіль їде зі швидкістю {Speed} км/год від {startPoint} до {endPoint}.");
    }
}

// Клас Bus
public class Bus : Vehicle
{
    public Bus()
    {
        Speed = 60;
        Capacity = 40;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Автобус їде зі швидкістю {Speed} км/год від {startPoint} до {endPoint}, вмістимість {Capacity} пасажирів.");
    }
}

// Клас Train
public class Train : Vehicle
{
    public Train()
    {
        Speed = 120;
        Capacity = 200;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Поїзд їде зі швидкістю {Speed} км/год від {startPoint} до {endPoint}, вмістимість {Capacity} пасажирів.");
    }
}

// Клас Human
public class Human
{
    public int Speed { get; set; }

    public Human(int speed)
    {
        Speed = speed;
    }

    public void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Людина рухається зі швидкістю {Speed} км/год від {startPoint} до {endPoint}.");
    }
}

// Клас Route
public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public void CalculateOptimalRoute(Vehicle vehicle)
    {
        Console.WriteLine($"Оптимальний маршрут для транспорту {vehicle.GetType().Name}: {StartPoint} -> {EndPoint} зі швидкістю {vehicle.Speed} км/год.");
    }
}

// Клас TransportNetwork
public class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.GetType().Name} додано до транспортної мережі.");
    }

    public void ManageTransport(Route route)
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move(route.StartPoint, route.EndPoint);
        }
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        // Створення транспортної мережі
        var network = new TransportNetwork();

        // Додавання транспорту
        var car = new Car();
        var bus = new Bus();
        var train = new Train();

        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        // Створення маршруту
        var route = new Route("Київ", "Львів");

        // Розрахунок оптимального маршруту
        route.CalculateOptimalRoute(car);

        // Керування транспортом
        network.ManageTransport(route);

        // Додавання людини
        var human = new Human(5);
        human.Move(route.StartPoint, route.EndPoint);
    }
}
