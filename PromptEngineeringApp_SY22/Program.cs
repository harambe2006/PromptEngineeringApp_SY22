using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEngineeringApp_SY22 { // ANVÄNDE KLASSERNA PÅ ETT OCH SAMMA CS FIL. 

    // KÄLLOR FÖR XML: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags

    /// <summary>
    /// Basklass för hantering av snabba operationer
    /// </summary>
    class Prompt {
        /// <summary>
        /// Fält för att lagra användarinmatningsuppmaningen.
        /// </summary>
        private string _promptText;

        /// <summary>
        /// Konstruktör för att initiera uppmaningstexten.
        /// </summary>
        /// <param name="text">Inmatningstexten</param> //
        public Prompt(string text) {
            _promptText = text;
        }

        /// <summary>
        /// Metod för att få uppmaningstexten.
        /// </summary>
        /// <returns>Returnerar den aktuella uppmaningstexten.</returns>
        public string GetPromptText() {
            return _promptText;
        }

        /// <summary>
        /// Metod för att ändra prompttexten.
        /// Kan åsidosättas(overriden) av härledda(derived) klasser.
        /// </summary>
        public virtual void ModifyPrompt() {
            // Standardbeteende kan utökas i härledda klasser
            Console.WriteLine("No modification applied.");
        }
    }

    /// <summary>
    /// Klass som lägger till ett suffix till prompten.
    /// </summary>
    class SuffixPrompt : Prompt {
        /// <summary>
        /// Konstruktör för att initiera prompten med ett suffix.
        /// </summary>
        /// <param name="text">Inmatningstexten.</param>
        public SuffixPrompt(string text) : base(text) { }

        /// <summary>
        /// Method to add a suffix to the prompt.
        /// </summary>
        public override void ModifyPrompt() {
            Console.WriteLine(GetPromptText() + " [Suffix Added]");
        }
    }

    /// <summary>
    /// Klass som lägger till ett prefix till prompten.
    /// </summary>
    class PrefixPrompt : Prompt {
        /// <summary>
        /// Konstruktör för att initiera prompten med ett prefix.
        /// </summary>
        /// <param name="text">The input prompt text.</param>
        public PrefixPrompt(string text) : base(text) { }

        /// <summary>
        /// Method to add a prefix to the prompt.
        /// </summary>
        public override void ModifyPrompt() {
            Console.WriteLine("[Prefix Added] " + GetPromptText());
        }
    }

    /// <summary>
    /// Class to handle the user interface and interactions.
    /// </summary>
    class PromptUI {
        /// <summary>
        /// Field to store the prompt instance.
        /// </summary>
        private Prompt _prompt;

        /// <summary>
        /// Method to display the user interface and handle the prompt engineering.
        /// </summary>
        public void Run() {
            Console.WriteLine("Welcome to the Simple Prompt Engineering App!");
            Console.WriteLine("Type a prompt and hit Enter:");

            // Read user input
            string userPrompt = Console.ReadLine();

            // Display menu options for prompt modification
            Console.WriteLine("\nSelect an option to modify the prompt:");
            Console.WriteLine("1. Add a suffix");
            Console.WriteLine("2. Add a prefix");
            Console.WriteLine("3. Exit");

            // Read user choice
            string choice = Console.ReadLine();

            // Process user choice
            switch (choice) {
                case "1":
                    _prompt = new SuffixPrompt(userPrompt);
                    break;
                case "2":
                    _prompt = new PrefixPrompt(userPrompt);
                    break;
                case "3":
                    Console.WriteLine("Exiting the app.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Exiting the app.");
                    return;
            }

            // Modify and display the prompt
            _prompt.ModifyPrompt();
        }
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program {
        /// <summary>
        /// Main method to start the application.
        /// </summary>
        static void Main(string[] args) {
            // Create a new instance of the UI class and run the application
            PromptUI promptUI = new PromptUI();
            promptUI.Run();
        }
    }
}
