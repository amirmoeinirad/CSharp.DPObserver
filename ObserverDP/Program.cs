
// Amir Moeini Rad
// September 2025

// Help from ChatGPT

// Main Concept: Observer Design Pattern
// In this pattern, an object, known as the subject, maintains a list of its dependents, called observers,
// and notifies them automatically of any state changes, usually by calling one of their methods.
// This pattern is particularly useful in scenarios where a change in one object needs to be reflected in multiple other objects
// without tight coupling between them.

// This is a simple example of the Observer Design Pattern in C#.
// This concept can also be implemented using events and delegates in C#,
// but here we are using interfaces to illustrate the pattern more explicitly.


namespace ObserverDP
{
    // The Subject Class
    // This class maintains a list of observers and notifies them of any state changes.
    class Stock
    {
        // List of observers
        private List<IObserver> observers = new List<IObserver>();
        // State of the subject (Stock Price)
        private int price;

        // Property to get/set the stock price
        public int Price
        {
            get => price;
            set
            {
                price = value;

                // Notify all observers of the change in price.
                Notify();
            }
        }

        // Method to attach or add a new observer.
        public void Attach(IObserver observer) => observers.Add(observer);

        // Method to detach or remove an observer.
        public void Detach(IObserver observer) => observers.Remove(observer);

        // Method to notify all observers of a change in state.
        private void Notify()
        {
            foreach (var observer in observers)
                observer.Update(price);

            Console.WriteLine();
        }
    }


    ////////////////////////////////////////////////


    // Observer interface
    interface IObserver
    {
        void Update(int price);
    }


    ////////////////////////////////////////////////
    

    // Concrete Observer (Observer Implementation)
    class Investor : IObserver
    {
        // Name of the investor
        private string name;

        // Constructor
        public Investor(string name) => this.name = name;

        // Update method to be called when the subject's state changes.
        public void Update(int price)
        {
            Console.WriteLine($"{name} notified: Stock price changed to {price}");
        }
    }


    ////////////////////////////////////////////////


    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Observer Design Pattern in C#.NET.");
            Console.WriteLine("----------------------------------\n");


            // Create a stock object. (The Subject)
            Stock stock = new Stock();

            // Create investors (Observers).
            Investor a = new Investor("Amir");
            Investor b = new Investor("Elham");

            // Adding observers to the list of observers in the stock.
            stock.Attach(a);
            stock.Attach(b);

            // Change the stock price and see how observers are notified.
            stock.Price = 100;
            stock.Price = 120;

            // Detach an observer and change the price again.
            stock.Detach(a);

            // Only Sara (investor b) will be notified this time.
            stock.Price = 90;

            Console.WriteLine("Done.");
        }
    }
}
