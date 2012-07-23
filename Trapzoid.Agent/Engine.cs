using System;
using System.Collections.Generic;

namespace Trapzoid.Agent {
  /// <summary>
  /// Calculates the state and makes the choice for the next move
  /// </summary>
  public class Engine {

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Engine() {      
      MoveResult = new World();
      Sensor = new Sensor();
    }

    #endregion

    #region Properties

    /// <summary> Sensor for the agent </summary>
    public Sensor Sensor { get; private set; }
    /// <summary> Result of the move </summary>
    public World MoveResult { get; private set; }
    /// <summary> Current position of the player </summary>
    public PlayerCell PlayerPosition { get; private set; }

    #endregion    

    #region Public Methods

    /// <summary>
    /// Loads the state of the current turn
    /// </summary>
    /// <param name="world">World state to load</param>
    /// <returns>True if the world was loaded succesfully</returns>
    public bool LoadCurrentTurn(string[] world) {      
      bool loaded = !Sensor.LoadCurrentTurn(world);
      return loaded;
    }

    /// <summary>
    /// Loads the state of the previous turn
    /// </summary>
    /// <param name="world">History state of the wolrd to load</param>
    public void RemeberLastTurn(string[] world) {
      Sensor.LoadLastTurn(world);
    }

    /// <summary>
    /// Processes the turn for the agent
    /// </summary>
    /// <returns>The state that the world will for the turn</returns>
    public World Process() {
      MoveResult.Cells = new Dictionary<int, Dictionary<int, Cell>>();
      for (int i = 0; i < Sensor.CurrentTurn.Cells.Count; i++) {
        MoveResult.Cells.Add(i, new Dictionary<int, Cell>());
        for (int j = 0; j < Sensor.CurrentTurn.Cells.Count; j++) {
          Cell cell = Sensor.CurrentTurn.Cells[i][j];
          if (cell.Content == CellContent.You) {
            PlayerPosition = (PlayerCell)cell;
            MoveResult.Cells[i].Add(j, new Cell() { X = i, Y = j, Content = CellContent.YourWall, Value = 0 });
          } else {
            MoveResult.Cells[i].Add(j, cell);
          }
        }
      }
      MovePlayer();
      return MoveResult;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Moves the player to an acceptable position
    /// </summary>
    private void MovePlayer() {
      MoveResult.Cells[PlayerPosition.X][PlayerPosition.Y].Content = CellContent.YourWall;
      PlayerPosition.X += 1;
      MoveResult.Cells[PlayerPosition.X][PlayerPosition.Y] = PlayerPosition;
    }

    #endregion    
  }
}