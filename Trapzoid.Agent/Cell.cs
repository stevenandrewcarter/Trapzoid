
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
    /// <summary> Cell North of the player position </summary>
    public Cell North { get; set; }
    /// <summary> Cell East of the player position </summary>
    public Cell East { get; set; }
    /// <summary> Cell South of the player position </summary>
    public Cell South { get; set; }
    /// <summary> Cell West of the player position </summary>
    public Cell West { get; set; }
    
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

    /// <summary>
    /// Calculates the value of the current cell
    /// </summary>
    public virtual void Calculate() {
      Cell northCell = North;
      Cell southCell = South;
      Cell eastCell = East;
      Cell westCell = West;
      int numberNorthMovesToWall = 0;
      int numberSouthMovesToWall = 0;
      int numberEastMovesToWall = 0;
      int numberWestMovesToWall = 0;
      while (northCell.Value != 0 && northCell != this) {
        numberNorthMovesToWall += 1;
        northCell = northCell.North;
      }
      while (southCell.Value != 0 && southCell != this) {
        numberSouthMovesToWall += 1;
        southCell = southCell.South;
      }
      while (eastCell.Value != 0 && eastCell != this) {
        numberEastMovesToWall += 1;
        eastCell = eastCell.East;
      }
      while (westCell.Value != 0 && westCell != this) {
        numberWestMovesToWall += 1;
        westCell = westCell.West;
      }
      double northValue = numberNorthMovesToWall / 29.0;
      double southValue = numberSouthMovesToWall / 29.0;
      double eastValue = numberEastMovesToWall / 29.0;
      double westValue = numberWestMovesToWall / 29.0;
      Value = (northValue + southValue + eastValue + westValue) / 4.0;      
    }

    #endregion
  }
}