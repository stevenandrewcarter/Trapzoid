using System;
using System.IO;
using Trapzoid.Agent;

namespace Trapzoid {
  class Program {
    static void Main(string[] args) {
      // Read the state of the world
      string[] world = File.ReadAllLines(@"worldstate.txt");
      var engine = new Engine(world);
      Console.Write(engine.Sensor.World.ToString());
      // Calculate next best move
      // Save state to memory
      // Write move to file    
      Console.Read();
    }
  }
}
