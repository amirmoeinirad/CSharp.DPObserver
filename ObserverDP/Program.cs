
// Amir Moeini Rad
// September 2025

// The Observer Design Pattern
// Version: 1.0 -> The notification process is implemented manually.

// This pattern defines a one-to-many dependency.
// An object, known as the subject, maintains a list of its dependents, called observers,
// and notifies them automatically of any state changes.
// This pattern is particularly useful in scenarios where a change in one object needs to be reflected in multiple other objects.


namespace ObserverDP
{
    // The Subject Class    
    internal class Stock
    {
        // List of observers
        private List<IObserver> observers = [];

        // State of the subject
        private int price;
        
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

        // Add a new observer to the list.
        public void Attach(IObserver observer) => observers.Add(observer);

        // Remove an observer from the list.
        public void Detach(IObserver observer) => observers.Remove(observer);

        // Notify all observers of a change in state.        
        private void Notify()
        {
            foreach (var observer in observers)
                observer.Update(price);

            Console.WriteLine();
        }
    }
    


    // Observer interface
    internal interface IObserver
    {
        void Update(int price);
    }
    


    // Concrete Observer
    internal class Investor : IObserver
    {       
        private string name;
        
        public Investor(string name) => this.name = name;

        // Update method to be called when the subject's state changes.
        public void Update(int price)
        {
            Console.WriteLine($"{name} notified: Stock price changed to {price}.");
        }
    }
    


    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The Observer Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------\n");


            // The Subject
            Stock stock = new();

            // Observers
            Investor a = new("Amir");
            Investor b = new("Elham");

            // Adding observers to the list of observers.
            stock.Attach(a);
            stock.Attach(b);

            // Change the stock price and see how observers are notified.
            stock.Price = 100;
            stock.Price = 120;
            stock.Price = 110;

            // Detach an observer and change the price again.
            stock.Detach(a);

            // Only Elham (investor b) will be notified this time.
            stock.Price = 90;

            Console.WriteLine("Done.");
        }
    }
}
