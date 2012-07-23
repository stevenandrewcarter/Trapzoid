
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
  /// Indicates the facing of the Cycle
  /// </summary>
  public enum Facings {
    North = 0,
    East = 1,
    South = 2,
    West = 3
  }

  /// <summary>
  /// Represents a position in the world
  /// </summary>
  public class Cell {

    #region Properties

    /// <summary> X Position of the Cell </summary>
    public int X { get; set; }
    /// <summary> Y Position of the Cell </summary>
    public int Y { get; set; }
    /// <summary> Content of the Cell </summary>
    public CellContent Content { get; set; }
    /// <summary> Value of the move to the cell </summary>
    public double Value { get; set; }

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
        case "OpponentWall": state = CellContent.OpponentWall; break;
      }
      return state;
    }

    public virtual int CompareTo(object obj) {      
      // Cast object to a cell
      Cell compareCell = (Cell)obj;
      return compareCell.X == X && compareCell.Y == Y ? 0 : 1;
    }

    #endregion
  }
}
