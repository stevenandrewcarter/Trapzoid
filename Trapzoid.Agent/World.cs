using System;
using System.Collections.Generic;

namespace Trapzoid.Agent {

  /// <summary>
  /// Represents the world
  /// </summary>
  public class World {    

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>    
    public World() {
      Cells = new Dictionary<int, Dictionary<int, Cell>>();
    }
    #endregion

    #region Properties
    /// <summary> Represents the world </summary>
    public Dictionary<int, Dictionary<int, Cell>> Cells { get; private set; }
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
          if (!Cells.ContainsKey(int.Parse(line[0]))) {
            Cells.Add(int.Parse(line[0]), new Dictionary<int, Cell>());
          }
          if (!Cells[int.Parse(line[0])].ContainsKey(int.Parse(line[1]))) {
            Cells[int.Parse(line[0])].Add(int.Parse(line[1]), new Cell() {
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
      for (int i = 0; i < Cells.Count; i++) {
        for (int j = 0; j < Cells.Count; j++) {
          switch (Cells[i][j].Content) {
            case CellContent.Opponent: Console.BackgroundColor = ConsoleColor.Red; break;
            case CellContent.OpponentWall: Console.BackgroundColor = ConsoleColor.DarkRed; break;
            case CellContent.You: Console.BackgroundColor = ConsoleColor.Blue; break;
            case CellContent.YourWall: Console.BackgroundColor = ConsoleColor.DarkBlue; break;
            case CellContent.Clear: Console.BackgroundColor = ConsoleColor.Gray; break;
          }
          Console.Write((int)Cells[i][j].Content);                                
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
      for (int i = 0; i < Cells.Count; i++) {
        for (int j = 0; j < Cells.Count; j++) {
          result += string.Format("{0} {1} {2}\r\n", Cells[i][j].X, Cells[i][j].Y, Cells[i][j].Content);
        }
      }
      return result;
    }
    #endregion
  }
}
