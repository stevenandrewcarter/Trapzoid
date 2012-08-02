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
    /// <summary> Current position of the opponent </summary>
    public OpponentCell OpponentPosition { get; private set; }

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
      // Create a new set for the results
      MoveResult.Cells = new Dictionary<int, Dictionary<int, Cell>>();
      for (int i = 0; i < Sensor.CurrentTurn.Cells.Count; i++) {
        MoveResult.Cells.Add(i, new Dictionary<int, Cell>());
        for (int j = 0; j < Sensor.CurrentTurn.Cells.Count; j++) {
          Cell cell = Sensor.CurrentTurn.Cells[i][j];
          Sensor.CurrentTurn.LoadPositions(cell);
          if (cell.Content == CellContent.You) {
            PlayerPosition = (PlayerCell)cell;
            MoveResult.Cells[i].Add(j, new Cell() { X = i, Y = j, Content = CellContent.YourWall, Value = 0 });
          } else if (cell.Content == CellContent.Opponent) {
            OpponentPosition = (OpponentCell)cell;
            MoveResult.Cells[i].Add(j, new Cell() { X = i, Y = j, Content = CellContent.OpponentWall, Value = 0 });
          } else {
            MoveResult.Cells[i].Add(j, cell);
          }          
        }
      }
      // Calculate the MoveResult
      CalculateBestMove();
      MovePlayer();
      MoveOpponent();
      return MoveResult;
    }    

    #endregion

    #region Private Methods

    private void CalculateBestMove() {
      for (int i = 0; i < Sensor.CurrentTurn.Cells.Count; i++) {
        for (int j = 0; j < Sensor.CurrentTurn.Cells.Count; j++) {
          Cell cell = MoveResult.Cells[i][j];
          if (cell.Content == CellContent.Clear) {
            cell.Calculate();
          }
        }
      }
    }

    private void MoveOpponent() {
      MoveResult.Cells[OpponentPosition.X][OpponentPosition.Y].Content = CellContent.OpponentWall;
      // Check facing
      Cell bestMove = OpponentPosition;
      if (OpponentPosition.North.Value > bestMove.Value) {
        bestMove = OpponentPosition.North;
      }
      if (OpponentPosition.South.Value > bestMove.Value) {
        bestMove = OpponentPosition.South;
      }
      if (OpponentPosition.East.Value > bestMove.Value) {
        bestMove = OpponentPosition.East;
      }
      if (OpponentPosition.West.Value > bestMove.Value) {
        bestMove = OpponentPosition.West;
      }
      bestMove.Content = CellContent.Opponent;
      MoveResult.Cells[bestMove.X][bestMove.Y] = bestMove;      
    }

    /// <summary>
    /// Moves the player to an acceptable position
    /// </summary>
    private void MovePlayer() {
      MoveResult.Cells[PlayerPosition.X][PlayerPosition.Y].Content = CellContent.YourWall;
      // Check facing
      Cell bestMove = PlayerPosition;
      if (PlayerPosition.North.Value > bestMove.Value) {
        bestMove = PlayerPosition.North;
      }
      if (PlayerPosition.South.Value > bestMove.Value) {
        bestMove = PlayerPosition.South;
      }
      if (PlayerPosition.East.Value > bestMove.Value) {
        bestMove = PlayerPosition.East;
      }
      if (PlayerPosition.West.Value > bestMove.Value) {
        bestMove = PlayerPosition.West;
      }
      bestMove.Content = CellContent.You;
      MoveResult.Cells[bestMove.X][bestMove.Y] = bestMove;      
    }

    #endregion    
  }
}