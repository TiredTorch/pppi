class Program
{
    private static void LoremSplit()
    {

        Console.WriteLine("Enter the amount of words: ");
        int wordsAmount = int.Parse(Console.ReadLine());

        string text = File.ReadAllText("./lorem.txt");

        string[] words = text.Split(' ');
        for (int i = 0; i < wordsAmount; i++)
        {
            Console.Write(words[i] + " ");
        }
        Console.WriteLine('\n');
    }
    // Method to display Mathematic Operations

    private static void MathOperation()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1) +");
            Console.WriteLine("2) -");
            Console.WriteLine("3) *");
            Console.WriteLine("4) /");
            Console.WriteLine("5) Exit");
            int operation = int.Parse(Console.ReadLine());

            Console.WriteLine("First number:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Second number:");
            double b = double.Parse(Console.ReadLine());

            double result = 0;
            switch (operation)
            {
                case 1:
                    result = a + b;
                    break;
                case 2:
                    result = a - b;
                    break;
                case 3:
                    result = a * b;
                    break;
                case 4:
                    result = a / b;
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
            Console.WriteLine("Res: " + result);
        }
    }

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1) Display number of words from text");
            Console.WriteLine("2) Perform mathematical operation");
            Console.WriteLine("3) Exit");

            int selection = int.Parse(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    LoremSplit();
                    break;
                case 2:
                    MathOperation();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
    }
}