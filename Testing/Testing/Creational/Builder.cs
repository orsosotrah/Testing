using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Builder Pattern
    /// 
    /// Intent:
    /// - Separate the construction of a complex object from its representation
    /// - Create different representations of an object using the same construction process
    /// - Isolate code for construction and representation
    /// 
    /// Applicability:
    /// - When the algorithm for creating a complex object should be independent of the parts that make up the object
    /// - When the construction process must allow different representations for the object that's constructed
    /// - When you need to build a complex object step by step (fluent interface)
    /// 
    /// Key aspects:
    /// - Builder interface that defines the steps to build parts of a product
    /// - Concrete Builder implementations with specific product knowledge
    /// - Director that constructs the object using the builder interface
    /// - Product which is the complex object being built
    /// </summary>

    #region Product

    // Product: the complex object we want to build
    public class House
    {
        // Required components
        public string Foundation { get; set; }
        public string Structure { get; set; }
        public string Roof { get; set; }

        // Optional components
        public string Interior { get; set; }
        public string Exterior { get; set; }
        public string Garden { get; set; }
        public string Garage { get; set; }
        public string SwimmingPool { get; set; }

        public void ShowDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nHouse Details:");
            sb.AppendLine($"- Foundation: {Foundation}");
            sb.AppendLine($"- Structure: {Structure}");
            sb.AppendLine($"- Roof: {Roof}");

            if (!string.IsNullOrEmpty(Interior))
                sb.AppendLine($"- Interior: {Interior}");

            if (!string.IsNullOrEmpty(Exterior))
                sb.AppendLine($"- Exterior: {Exterior}");

            if (!string.IsNullOrEmpty(Garden))
                sb.AppendLine($"- Garden: {Garden}");

            if (!string.IsNullOrEmpty(Garage))
                sb.AppendLine($"- Garage: {Garage}");

            if (!string.IsNullOrEmpty(SwimmingPool))
                sb.AppendLine($"- Swimming Pool: {SwimmingPool}");

            Console.WriteLine(sb.ToString());
        }
    }

    #endregion

    #region Builder Interface

    // Builder interface
    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildStructure();
        void BuildRoof();
        void BuildInterior();
        void BuildExterior();
        void BuildGarden();
        void BuildGarage();
        void BuildSwimmingPool();
        House GetHouse();
    }

    #endregion

    #region Concrete Builders

    // Concrete Builder for a standard house
    public class StandardHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation()
        {
            _house.Foundation = "Standard concrete foundation";
            Console.WriteLine("Standard House: Building standard concrete foundation");
        }

        public void BuildStructure()
        {
            _house.Structure = "Wooden frame structure";
            Console.WriteLine("Standard House: Building wooden frame structure");
        }

        public void BuildRoof()
        {
            _house.Roof = "Standard shingle roof";
            Console.WriteLine("Standard House: Building standard shingle roof");
        }

        public void BuildInterior()
        {
            _house.Interior = "Basic interior with standard finishes";
            Console.WriteLine("Standard House: Building basic interior with standard finishes");
        }

        public void BuildExterior()
        {
            _house.Exterior = "Vinyl siding exterior";
            Console.WriteLine("Standard House: Building vinyl siding exterior");
        }

        public void BuildGarden()
        {
            _house.Garden = "Small garden with basic landscaping";
            Console.WriteLine("Standard House: Building small garden with basic landscaping");
        }

        public void BuildGarage()
        {
            _house.Garage = "Single car garage";
            Console.WriteLine("Standard House: Building single car garage");
        }

        public void BuildSwimmingPool()
        {
            // Not included in a standard house
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    // Concrete Builder for a luxury house
    public class LuxuryHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation()
        {
            _house.Foundation = "Reinforced concrete foundation with waterproofing";
            Console.WriteLine("Luxury House: Building reinforced concrete foundation with waterproofing");
        }

        public void BuildStructure()
        {
            _house.Structure = "Steel and concrete structure with high insulation";
            Console.WriteLine("Luxury House: Building steel and concrete structure with high insulation");
        }

        public void BuildRoof()
        {
            _house.Roof = "Slate tile roof with advanced insulation";
            Console.WriteLine("Luxury House: Building slate tile roof with advanced insulation");
        }

        public void BuildInterior()
        {
            _house.Interior = "Premium interior with marble floors and designer furniture";
            Console.WriteLine("Luxury House: Building premium interior with marble floors and designer furniture");
        }

        public void BuildExterior()
        {
            _house.Exterior = "Stone facade exterior with premium finishes";
            Console.WriteLine("Luxury House: Building stone facade exterior with premium finishes");
        }

        public void BuildGarden()
        {
            _house.Garden = "Large landscaped garden with fountain and lighting";
            Console.WriteLine("Luxury House: Building large landscaped garden with fountain and lighting");
        }

        public void BuildGarage()
        {
            _house.Garage = "Three car garage with automated doors";
            Console.WriteLine("Luxury House: Building three car garage with automated doors");
        }

        public void BuildSwimmingPool()
        {
            _house.SwimmingPool = "Large heated swimming pool with jacuzzi";
            Console.WriteLine("Luxury House: Building large heated swimming pool with jacuzzi");
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    #endregion

    #region Director

    // Director class that orchestrates the building steps
    public class HouseDirector
    {
        private IHouseBuilder _builder;

        public HouseDirector(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(IHouseBuilder builder)
        {
            _builder = builder;
        }

        // Build a minimal house with just the essential parts
        public void BuildMinimalHouse()
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();
        }

        // Build a full featured house with all components
        public void BuildFullFeaturedHouse()
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();
            _builder.BuildInterior();
            _builder.BuildExterior();
            _builder.BuildGarden();
            _builder.BuildGarage();
            _builder.BuildSwimmingPool();
        }

        // Build a house with specific customizations
        public void BuildCustomHouse(bool interior, bool exterior, bool garden, bool garage, bool swimmingPool)
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();

            if (interior) _builder.BuildInterior();
            if (exterior) _builder.BuildExterior();
            if (garden) _builder.BuildGarden();
            if (garage) _builder.BuildGarage();
            if (swimmingPool) _builder.BuildSwimmingPool();
        }
    }

    #endregion

    #region Fluent Builder Implementation

    // Alternative: Fluent Builder implementation
    public class FluentHouseBuilder
    {
        private House _house = new House();

        public FluentHouseBuilder WithFoundation(string foundation)
        {
            _house.Foundation = foundation;
            Console.WriteLine($"Fluent Builder: Building foundation: {foundation}");
            return this;
        }

        public FluentHouseBuilder WithStructure(string structure)
        {
            _house.Structure = structure;
            Console.WriteLine($"Fluent Builder: Building structure: {structure}");
            return this;
        }

        public FluentHouseBuilder WithRoof(string roof)
        {
            _house.Roof = roof;
            Console.WriteLine($"Fluent Builder: Building roof: {roof}");
            return this;
        }

        public FluentHouseBuilder WithInterior(string interior)
        {
            _house.Interior = interior;
            Console.WriteLine($"Fluent Builder: Building interior: {interior}");
            return this;
        }

        public FluentHouseBuilder WithExterior(string exterior)
        {
            _house.Exterior = exterior;
            Console.WriteLine($"Fluent Builder: Building exterior: {exterior}");
            return this;
        }

        public FluentHouseBuilder WithGarden(string garden)
        {
            _house.Garden = garden;
            Console.WriteLine($"Fluent Builder: Building garden: {garden}");
            return this;
        }

        public FluentHouseBuilder WithGarage(string garage)
        {
            _house.Garage = garage;
            Console.WriteLine($"Fluent Builder: Building garage: {garage}");
            return this;
        }

        public FluentHouseBuilder WithSwimmingPool(string swimmingPool)
        {
            _house.SwimmingPool = swimmingPool;
            Console.WriteLine($"Fluent Builder: Building swimming pool: {swimmingPool}");
            return this;
        }

        public House Build()
        {
            return _house;
        }
    }

    #endregion

    /// <summary>
    /// Demo class showing how to use the Builder pattern
    /// </summary>
    public class BuilderDemo
    {
        public static void Run()
        {
            Console.WriteLine("===== Builder Pattern Demo =====");

            // Using the Director with different builders
            Console.WriteLine("\n1. Building a minimal standard house:");
            var standardBuilder = new StandardHouseBuilder();
            var director = new HouseDirector(standardBuilder);
            director.BuildMinimalHouse();
            House standardHouse = standardBuilder.GetHouse();
            standardHouse.ShowDetails();

            Console.WriteLine("\n2. Building a full featured luxury house:");
            var luxuryBuilder = new LuxuryHouseBuilder();
            director.ChangeBuilder(luxuryBuilder);
            director.BuildFullFeaturedHouse();
            House luxuryHouse = luxuryBuilder.GetHouse();
            luxuryHouse.ShowDetails();

            Console.WriteLine("\n3. Building a custom standard house:");
            var customBuilder = new StandardHouseBuilder();
            director.ChangeBuilder(customBuilder);
            director.BuildCustomHouse(
                interior: true,
                exterior: true,
                garden: false,
                garage: true,
                swimmingPool: false);
            House customHouse = customBuilder.GetHouse();
            customHouse.ShowDetails();

            // Using the Fluent Builder
            Console.WriteLine("\n4. Using the Fluent Builder:");
            House fluentHouse = new FluentHouseBuilder()
                .WithFoundation("Deep concrete foundation")
                .WithStructure("Brick structure")
                .WithRoof("Metal roof")
                .WithInterior("Modern interior")
                .WithGarage("Double garage")
                .Build();
            fluentHouse.ShowDetails();
        }
    }
}