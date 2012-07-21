
using System;
namespace Trapzoid {
  
  /// <summary>
  /// Internal States of the world
  /// </summary>
  public enum WorldState {
    Clear = 0,
    OwnWall = 1,
    Player = 2,
    Enemy = 3,
    EnemyWall = 4
  }

  /// <summary>
  /// Represents the world
  /// </summary>
  public class World {
    #region Private variables
    /// <summary> Represents the world </summary>
    private WorldState[,] world;
    private int width;
    private int height;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="world">String of the world state</param>
    public World(string[] world) {
      BuildWorld(world);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Builds the world from the input given as a string
    /// </summary>
    /// <param name="newWorld"></param>
    /// <returns></returns>
    private bool BuildWorld(string[] newWorld) {
      bool builtWorld = false;
      if (newWorld.Length > 0) {
        width = 30;
        height = 30; 
        world = new WorldState[width, height];
        for (var i = 0; i < newWorld.Length; i++) {
          string[] line = newWorld[i].Split(' ');
          world[int.Parse(line[0]), int.Parse(line[1])] = GetWorldState(line[2]);
        }
        builtWorld = true;
      }
      return builtWorld;
    }

    /// <summary>
    /// Displays the world
    /// </summary>    
    public void DisplayWorld() {
      for (var i = 0; i < width; i++) {
        for (var j = 0; j < height; j++) {
          switch (world[i, j]) {
            case WorldState.Enemy: Console.BackgroundColor = ConsoleColor.Red; break;
            case WorldState.EnemyWall: Console.BackgroundColor = ConsoleColor.DarkRed; break;
            case WorldState.Player: Console.BackgroundColor = ConsoleColor.Blue; break;
            case WorldState.OwnWall: Console.BackgroundColor = ConsoleColor.DarkBlue; break;
            case WorldState.Clear: Console.BackgroundColor = ConsoleColor.Gray; break;
          }
          Console.Write((int)world[i, j]);          
        }
        Console.WriteLine();
      }      
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Determines the World State from the input
    /// </summary>
    /// <param name="worldState"></param>
    /// <returns></returns>
    private WorldState GetWorldState(string worldState) {
      WorldState state = WorldState.Clear;
      switch (worldState) {
        case "Clear": state = WorldState.Clear; break;
        case "YourWall": state = WorldState.OwnWall; break;
        case "You": state = WorldState.Player; break;
        case "Opponent": state = WorldState.Enemy; break;
        case "OppenentWall": state = WorldState.EnemyWall; break;
      }
      return state;
    }
    #endregion
  }
}
