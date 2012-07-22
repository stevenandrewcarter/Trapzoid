using System;
using System.IO;
using Trapzoid.Agent;

namespace Trapzoid {
  class Program {
    static void Main(string[] args) {
      // Read the state of the world
      string[] world = File.ReadAllLines(args[0]);
      var engine = new Engine(world);
      engine.Sensor.World.DisplayWorld();
      // Calculate next best move
      var turnResult = engine.Process();
      // Save state to memory
      // Write move to file  
      string writeToFile = turnResult.GetWorld();
      File.WriteAllText(args[0], writeToFile);
      Console.Read();
    }
  }
}
