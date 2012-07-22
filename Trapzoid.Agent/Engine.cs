using System;

namespace Trapzoid.Agent {
  /// <summary>
  /// Calculates the state and makes the choice for the next move
  /// </summary>
  public class Engine {

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Engine(string[] world) {
      Sensor = new Sensor();
      if (!Sensor.Sense(world)) {
        throw new Exception("Critical Failure: Could not detect the world");
      }
    }
    #endregion

    #region Properties
    /// <summary> Sensor for the agent </summary>
    public Sensor Sensor { get; private set; }
    /// <summary> Result of the move </summary>
    public World MoveResult { get; private set; }
    public Cell PlayerPosition { get; private set; }
    #endregion

    #region Public Methods
    /// <summary>
    /// Processes the turn for the agent
    /// </summary>
    /// <returns>The state that the world will for the turn</returns>
    public World Process() {
      for (int i = 0; i < Sensor.World.Cells.Count; i++) {
        for (int j = 0; j < Sensor.World.Cells.Count; j++) {
          if (Sensor.World.Cells[i][j].Content == CellContent.You) {
            PlayerPosition = Sensor.World.Cells[i][j];
          }
        }
      }
      MoveResult = Sensor.World;
      return MoveResult;
    }
    #endregion
  }
}