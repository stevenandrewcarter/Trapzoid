using System;
using System.IO;
using Trapzoid.Agent;

namespace Trapzoid {
  class Program {    

    static void Main(string[] args) {
      var engine = new Engine();
      // Read the previous state of the world
      engine = ReadPreviousWorld(engine, "history.state");
      // Read the state of the world
      engine = ReadCurrentWorld(engine, args[0]);
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

    private static Engine ReadPreviousWorld(Engine engine, string historyWorld) {
      if (File.Exists(historyWorld)) {
        string[] world = File.ReadAllLines(historyWorld);
        engine.RemeberLastTurn(world);
      }
      return engine;
    }

    private static Engine ReadCurrentWorld(Engine engine, string currentWorld) {
      string[] world = File.ReadAllLines(currentWorld);
      engine.SenseCurrentWorld(world);
      engine.Sensor.CurrentTurn.DisplayWorld();
      return engine;
    }
  }
}
