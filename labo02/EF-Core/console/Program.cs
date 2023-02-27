using Globals;
using Logica;

internal class Program {
    private static void Main(string[] args) {
        DataPreProcessor dpp = new DataPreProcessor();
        List<Swimmer> swimmers = dpp.GetSwimmers();
        foreach(var s in swimmers) {
            Console.WriteLine(s);
        }
    }
}