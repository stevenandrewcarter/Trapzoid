using System;
using System.IO;
using Trapzoid.Agent;

namespace Trapzoid {
  class Program {    

    static void Main(string[] args) {      
      while (true) {
        Console.SetCursorPosition(0, 0);
        var engine = new Engine();
        // Read the previous state of the world
        engine = LoadPreviousTurn(engine, "history.state");
        // Read the state of the world
        engine = LoadCurrentTurn(engine, args[0]);
        // Save the state of the world to history
        SaveTurnState("history.state", engine.Sensor.CurrentTurn.GetWorld());        
        // Calculate next best move
        var turnResult = engine.Process();        
        // Write move to file         
        SaveTurnState(args[0], turnResult.GetWorld());                
      }
    }

    private static void SaveTurnState(string fileName, string turnState) {
      File.WriteAllText(fileName, turnState);
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
