using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Factory Method Pattern
    /// 
    /// Intent:
    /// - Define an interface for creating an object, but let subclasses decide which class to instantiate
    /// - Lets a class defer instantiation to subclasses
    /// - Creates objects without exposing the instantiation logic
    /// 
    /// Applicability:
    /// - When a class can't anticipate the class of objects it must create
    /// - When a class wants its subclasses to specify the objects it creates
    /// - When classes delegate responsibility to one of several helper subclasses,
    ///   and you want to localize the knowledge of which helper subclass is the delegate
    /// 
    /// Key aspects:
    /// - Creator classes that declare the factory method
    /// - Concrete creators that override the factory method
    /// - Product interface that declares the interface of objects the factory creates
    /// - Concrete products that implement the product interface
    /// </summary>

    #region Product

    // Product interface
    public interface IVehicle
    {
        void Drive();
    }

    // Concrete Product A
    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("The car is being driven");
        }
    }

    // Concrete Product B
    public class Motorcycle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("The motorcycle is being driven");
        }
    }

    // Concrete Product C
    public class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("The truck is being driven");
        }
    }

    #endregion

    #region Creator

    // Creator - declares the factory method
    public abstract class VehicleFactory
    {
        // Factory Method
        public abstract IVehicle CreateVehicle();

        // Template method that uses the factory method
        public void TestVehicle()
        {
            IVehicle vehicle = CreateVehicle();
            Console.WriteLine("Testing vehicle...");
            vehicle.Drive();
        }
    }

    // Concrete Creator A
    public class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }

    // Concrete Creator B
    public class MotorcycleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Motorcycle();
        }
    }

    // Concrete Creator C
    public class TruckFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Truck();
        }
    }

    #endregion

    #region Simple Factory (not a GoF pattern but commonly used)

    // Simple Factory - alternative approach
    public class SimpleVehicleFactory
    {
        public enum VehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        public IVehicle CreateVehicle(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car:
                    return new Car();
                case VehicleType.Motorcycle:
                    return new Motorcycle();
                case VehicleType.Truck:
                    return new Truck();
                default:
                    throw new ArgumentException($"Invalid vehicle type: {type}");
            }
        }
    }

    #endregion

    /// <summary>
    /// Demo class showing how to use the Factory Method pattern
    /// </summary>
    public class FactoryMethodDemo
    {
        public static void Run()
        {
            Console.WriteLine("===== Factory Method Pattern Demo =====");

            // Create factories
            VehicleFactory carFactory = new CarFactory();
            VehicleFactory motorcycleFactory = new MotorcycleFactory();
            VehicleFactory truckFactory = new TruckFactory();

            // Use factories to create products
            IVehicle car = carFactory.CreateVehicle();
            IVehicle motorcycle = motorcycleFactory.CreateVehicle();
            IVehicle truck = truckFactory.CreateVehicle();

            // Use products
            car.Drive();
            motorcycle.Drive();
            truck.Drive();

            // Use template method
            Console.WriteLine("\nTesting vehicles with template method:");
            carFactory.TestVehicle();
            motorcycleFactory.TestVehicle();

            // Simple Factory usage
            Console.WriteLine("\nUsing Simple Factory:");
            SimpleVehicleFactory simpleFactory = new SimpleVehicleFactory();
            IVehicle simpleCar = simpleFactory.CreateVehicle(SimpleVehicleFactory.VehicleType.Car);
            simpleCar.Drive()
        }
    }
}