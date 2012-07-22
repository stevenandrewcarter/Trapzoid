using System;
using System.Collections.Generic;

namespace Trapzoid.Agent {

  /// <summary>
  /// Represents the world
  /// </summary>
  public class World {
    #region Private variables
    /// <summary> Represents the world </summary>
    private Dictionary<int, Dictionary<int, Cell>> cells;    
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>    
    public World() {
      cells = new Dictionary<int, Dictionary<int, Cell>>();
    }
    #endregion

    #region Properties
    #endregion

    #region Public Methods
    /// <summary>
    /// Builds the world from the input given as a string
    /// </summary>
    /// <param name="newWorld"></param>
    /// <returns></returns>
    public bool BuildWorld(string[] newWorld) {
      bool builtWorld = false;
      if (newWorld.Length > 0) {
        for (var i = 0; i < newWorld.Length; i++) {
          string[] line = newWorld[i].Split(' ');
          if (!cells.ContainsKey(int.Parse(line[0]))) {
            cells.Add(int.Parse(line[0]), new Dictionary<int, Cell>());
          }
          if (!cells[int.Parse(line[0])].ContainsKey(int.Parse(line[1]))) {
            cells[int.Parse(line[0])].Add(int.Parse(line[1]), new Cell() {
              X = int.Parse(line[0]),
              Y = int.Parse(line[1]),
              Content = Cell.GetWorldState(line[2])
            });
          }
          builtWorld = true;
        }
      }
      return builtWorld;
    }

    /// <summary>
    /// Displays the world
    /// </summary>    
    public void DisplayWorld() {      
      for (int i = 0; i < cells.Count; i++) {
        for (int j = 0; j < cells.Count; j++) {
          switch (cells[i][j].Content) {
            case CellContent.Opponent: Console.BackgroundColor = ConsoleColor.Red; break;
            case CellContent.OpponentWall: Console.BackgroundColor = ConsoleColor.DarkRed; break;
            case CellContent.You: Console.BackgroundColor = ConsoleColor.Blue; break;
            case CellContent.YourWall: Console.BackgroundColor = ConsoleColor.DarkBlue; break;
            case CellContent.Clear: Console.BackgroundColor = ConsoleColor.Gray; break;
          }
          Console.Write((int)cells[i][j].Content);                                
        }
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Gets the world as a string
    /// </summary>
    /// <returns></returns>
    public string GetWorld() {
      string result = "";
      for (int i = 0; i < cells.Count; i++) {
        for (int j = 0; j < cells.Count; j++) {
          result += string.Format("{0} {1} {2}\r\n", cells[i][i].X, cells[i][i].Y, cells[i][i].Content);
        }
      }
      return result;
    }
    #endregion
  }
}
