using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trapzoid.Agent {

  /// <summary>
  /// Internal States of the world
  /// </summary>
  public enum CellContent {
    Clear = 0,
    YourWall = 1,
    You = 2,
    Opponent = 3,
    OpponentWall = 4
  }

  /// <summary>
  /// Represents a position in the world
  /// </summary>
  public class Cell {
    #region Properties
    public int X { get; set; }
    public int Y { get; set; }
    public CellContent Content { get; set; }
    #endregion

    #region Public Methods
    /// <summary>
    /// Determines the World State from the input
    /// </summary>
    /// <param name="worldState">String representation of the cell content</param>
    /// <returns>The CellContent</returns>
    public static CellContent GetWorldState(string worldState) {
      CellContent state = CellContent.Clear;
      switch (worldState) {
        case "Clear": state = CellContent.Clear; break;
        case "YourWall": state = CellContent.YourWall; break;
        case "You": state = CellContent.You; break;
        case "Opponent": state = CellContent.Opponent; break;
        case "OppenentWall": state = CellContent.OpponentWall; break;
      }
      return state;
    }
    #endregion
  }
}
