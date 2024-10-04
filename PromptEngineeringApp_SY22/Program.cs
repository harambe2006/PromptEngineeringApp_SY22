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
        /// <param name="text">Inmatningstexten</param> 
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
            Console.WriteLine("Ingen ändring tillämpad.");
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
        /// Metod för att lägga till ett suffix till prompten.
        /// </summary>
        public override void ModifyPrompt() {
            Console.WriteLine(GetPromptText() + " [Suffix har lagts till]");
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
        /// Metod för att lägga till ett prefix till prompten.
        /// </summary>
        public override void ModifyPrompt() {
            Console.WriteLine("[Prefix har lagts till] " + GetPromptText());
        }
    }

    /// <summary>
    /// Klass för att hantera användargränssnittet och interaktioner.
    /// </summary>
    class PromptUI {
        /// <summary>
        /// Fält för att lagra promptinstansen.
        /// </summary>
        private Prompt _prompt;

        /// <summary>
        /// Metod för att visa användargränssnittet och hantera den snabba konstruktionen.
        /// </summary>
        public void Run() {
            Console.WriteLine("Välkommen till Simple Prompt Engineering-appen!");
            Console.WriteLine("Skriv en prompt och tryck på Enter:");

            // Läs användarinmatning
            string userPrompt = Console.ReadLine();

            // Visa menyalternativ för snabb ändring
            Console.WriteLine("\nVälj ett alternativ för att ändra prompten:");
            Console.WriteLine("1. Lägg till ett suffix");
            Console.WriteLine("2. Lägg till ett prefix");
            Console.WriteLine("3. Exit");

            // Läs användarens val
            string myChoice = Console.ReadLine();

            // Bearbeta användarens val
            switch (myChoice) {
                case "1":
                    _prompt = new SuffixPrompt(userPrompt);
                    break;
                case "2":
                    _prompt = new PrefixPrompt(userPrompt);
                    break;
                case "3":
                    Console.WriteLine("Avslutar appen.");
                    return;
                default:
                    Console.WriteLine("Ogiltigt alternativ. Avslutar appen.");
                    return;
            }

            // Ändra och visa uppmaningen
            _prompt.ModifyPrompt();
        }
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program {
        /// <summary>
        /// Huvudmetod för att starta applikationen.
        /// </summary>
        static void Main(string[] args) {
            // Skapa en ny instans av UI-klassen och kör applikationen
            PromptUI promptUI = new PromptUI();
            promptUI.Run();


        }
    }
}
