using System;
using System.IO;
using Trapzoid.Agent;

namespace Trapzoid {
  class Program {    

    static void Main(string[] args) {
      var engine = new Engine();
      // Read the previous state of the world
      engine = LoadPreviousTurn(engine, "history.state");
      // Read the state of the world
      engine = LoadCurrentTurn(engine, args[0]);
      Console.Read();
      // Calculate next best move
      var turnResult = engine.Process();
      // Save state to memory
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
      turnResult.DisplayWorld();
      // Write move to file  
      string writeToFile = turnResult.GetWorld();
      File.WriteAllText("history.state", writeToFile);
      Console.ReadLine();
    }

    /// <summary>
    /// Loads the previous state of the world
    /// </summary>
    /// <param name="engine">Agent engine</param>
    /// <param name="historyWorld">Location of the history state file</param>
    /// <returns>Engine with the loaded previous turn</returns>
    private static Engine LoadPreviousTurn(Engine engine, string historyWorld) {
      if (File.Exists(historyWorld)) {
        string[] world = File.ReadAllLines(historyWorld);
        engine.RemeberLastTurn(world);
      }
      return engine;
    }

    /// <summary>
    /// Loads the current state of the world
    /// </summary>
    /// <param name="engine">Agent engine</param>
    /// <param name="currentWorld">Location of the current state file</param>
    /// <returns>Engine with the current turn</returns>
    private static Engine LoadCurrentTurn(Engine engine, string currentWorld) {
      string[] world = File.ReadAllLines(currentWorld);
      engine.LoadCurrentTurn(world);
      engine.Sensor.CurrentTurn.DisplayWorld();
      return engine;
    }
  }
}
