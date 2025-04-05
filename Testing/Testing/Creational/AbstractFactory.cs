using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Abstract Factory Pattern
    /// 
    /// Intent:
    /// - Provide an interface for creating families of related or dependent objects
    ///   without specifying their concrete classes
    /// - A hierarchy that encapsulates many possible "platforms" and the construction of a
    ///   suite of "products"
    /// 
    /// Applicability:
    /// - When a system should be independent of how its products are created, composed, and represented
    /// - When a system should be configured with one of multiple families of products
    /// - When a family of related product objects is designed to be used together
    /// - When you want to provide a class library of products, and you want to reveal just their interfaces, not their implementations
    /// 
    /// Key aspects:
    /// - Abstract Factory interface that declares creation methods for products
    /// - Concrete Factories that implement creation methods
    /// - Abstract Product interfaces that declare product interfaces
    /// - Concrete Products that implement the product interfaces
    /// - Client that uses only interfaces declared by Abstract Factory and Abstract Product
    /// </summary>

    #region Abstract Products

    // Abstract Product A
    public interface IButton
    {
        void Render();
        void HandleClick();
    }

    // Abstract Product B
    public interface ITextBox
    {
        void Render();
        void HandleInput();
    }

    // Abstract Product C
    public interface ICheckbox
    {
        void Render();
        void Toggle();
    }

    #endregion

    #region Concrete Products - Windows Family

    // Concrete Product A1
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a button in Windows style");
        }

        public void HandleClick()
        {
            Console.WriteLine("Windows button click handled");
        }
    }

    // Concrete Product B1
    public class WindowsTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a textbox in Windows style");
        }

        public void HandleInput()
        {
            Console.WriteLine("Windows textbox input handled");
        }
    }

    // Concrete Product C1
    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a checkbox in Windows style");
        }

        public void Toggle()
        {
            Console.WriteLine("Windows checkbox toggled");
        }
    }

    #endregion

    #region Concrete Products - MacOS Family

    // Concrete Product A2
    public class MacOSButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a button in MacOS style");
        }

        public void HandleClick()
        {
            Console.WriteLine("MacOS button click handled");
        }
    }

    // Concrete Product B2
    public class MacOSTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a textbox in MacOS style");
        }

        public void HandleInput()
        {
            Console.WriteLine("MacOS textbox input handled");
        }
    }

    // Concrete Product C2
    public class MacOSCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a checkbox in MacOS style");
        }

        public void Toggle()
        {
            Console.WriteLine("MacOS checkbox toggled");
        }
    }

    #endregion

    #region Abstract Factory and Concrete Factories

    // Abstract Factory
    public interface IGUIFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
        ICheckbox CreateCheckbox();
    }

    // Concrete Factory 1
    public class WindowsGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ITextBox CreateTextBox()
        {
            return new WindowsTextBox();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    // Concrete Factory 2
    public class MacOSGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public ITextBox CreateTextBox()
        {
            return new MacOSTextBox();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacOSCheckbox();
        }
    }

    #endregion

    #region Client

    // Client class that uses the Abstract Factory
    public class Application
    {
        private readonly IButton _button;
        private readonly ITextBox _textBox;
        private readonly ICheckbox _checkbox;

        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _textBox = factory.CreateTextBox();
            _checkbox = factory.CreateCheckbox();
        }

        public void RenderUI()
        {
            _button.Render();
            _textBox.Render();
            _checkbox.Render();
        }

        public void HandleUserInteraction()
        {
            _button.HandleClick();
            _textBox.HandleInput();
            _checkbox.Toggle();
        }
    }

    #endregion

    /// <summary>
    /// Demo class showing how to use the Abstract Factory pattern
    /// </summary>
    public class AbstractFactoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("===== Abstract Factory Pattern Demo =====");

            // Create Windows application
            Console.WriteLine("\nCreating Windows application:");
            IGUIFactory windowsFactory = new WindowsGUIFactory();
            Application windowsApp = new Application(windowsFactory);
            windowsApp.RenderUI();
            windowsApp.HandleUserInteraction();

            // Create MacOS application
            Console.WriteLine("\nCreating MacOS application:");
            IGUIFactory macosFactory = new MacOSGUIFactory();
            Application macosApp = new Application(macosFactory);
            macosApp.RenderUI();
            macosApp.HandleUserInteraction();

            // Demonstrate how we can configure an application with different factories
            Console.WriteLine("\nConfiguring application based on operating system:");
            string os = Environment.OSVersion.Platform.ToString().Contains("Win") ? "Windows" : "MacOS";
            Console.WriteLine($"Detected OS: {os}");

            IGUIFactory factory = os == "Windows" ? new WindowsGUIFactory() : new MacOSGUIFactory();
            Application app = new Application(factory);
            app.RenderUI();
        }
    }
}