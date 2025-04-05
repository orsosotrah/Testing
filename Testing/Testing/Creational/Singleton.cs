using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Singleton Pattern
    /// 
    /// Intent:
    /// - Ensure a class has only one instance and provide a global point of access to it
    /// - Encapsulated "just-in-time initialization" or "initialization on first use"
    /// 
    /// Applicability:
    /// - When there must be exactly one instance of a class, and it must be accessible from a well-known point
    /// - When the sole instance should be extensible by subclassing, and clients should be able to use an extended instance without modifying their code
    /// 
    /// Key aspects:
    /// - Private constructor to prevent direct instantiation
    /// - Private static instance variable to hold the singleton instance
    /// - Public static method that returns the singleton instance
    /// </summary>

    // Thread-safe Singleton with lazy initialization
    public sealed class Singleton
    {
        // Lazy<T> handles thread safety and lazy initialization
        private static readonly Lazy<Singleton> _instance =
            new Lazy<Singleton>(() => new Singleton());

        // Private constructor prevents direct instantiation
        private Singleton()
        {
            Console.WriteLine("Singleton instance created");
        }

        // Public access point to the singleton instance
        public static Singleton Instance => _instance.Value;

        // Example method on the singleton
        public void DoSomething()
        {
            Console.WriteLine("Singleton is doing something");
        }
    }

    // Alternative implementation: Double-check locking pattern
    public sealed class SingletonDoubleCheck
    {
        private static SingletonDoubleCheck _instance;
        private static readonly object _lock = new object();

        private SingletonDoubleCheck() { }

        public static SingletonDoubleCheck Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonDoubleCheck();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    // Alternative implementation: Static initialization
    public sealed class SingletonStatic
    {
        // Static constructor ensures thread safety for static fields
        private static readonly SingletonStatic _instance = new SingletonStatic();

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static SingletonStatic() { }

        private SingletonStatic() { }

        public static SingletonStatic Instance => _instance;
    }

    /// <summary>
    /// Demo class showing how to use the Singleton pattern
    /// </summary>
    public class SingletonDemo
    {
        public static void Run()
        {
            // Access the singleton instance
            Singleton instance1 = Singleton.Instance;
            instance1.DoSomething();

            // Get the instance again - same instance will be returned
            Singleton instance2 = Singleton.Instance;

            // Demonstrate both references point to the same object
            Console.WriteLine($"Same instance? {ReferenceEquals(instance1, instance2)}");
            // Output: Same instance? True

            // Lazy initialization means the instance is not created until it's accessed
            Console.WriteLine("Accessing another singleton implementation:");
            var instance3 = SingletonDoubleCheck.Instance;
            var instance4 = SingletonStatic.Instance;
        }
    }
}