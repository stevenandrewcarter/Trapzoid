
namespace Trapzoid.Agent {

  /// <summary>
  /// Represents the agents view of the world
  /// </summary>
  public class Sensor {

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Sensor() {
      CurrentTurn = new World();
      CurrentTurn.LoadOpponentPositionEvent += new LoadOpponentPositionEventHandler(CurrentTurn_LoadOpponentPositionEvent);
      CurrentTurn.LoadPlayerPositionEvent += new LoadPlayerPositionEventHandler(CurrentTurn_LoadPlayerPositionEvent);
      LastTurn = new World();
      LastTurn.LoadOpponentPositionEvent += new LoadOpponentPositionEventHandler(LastTurn_LoadOpponentPositionEvent);
      LastTurn.LoadPlayerPositionEvent += new LoadPlayerPositionEventHandler(LastTurn_LoadPlayerPositionEvent);
      PlayerCell = new PlayerCell();
      OpponentCell = new OpponentCell();
    }

    #endregion

    #region Properties

    /// <summary> Current state of the world </summary>
    public World CurrentTurn { get; private set; }
    /// <summary> Last state of the world </summary>
    public World LastTurn { get; private set; }
    /// <summary> Player cell </summary>
    public PlayerCell PlayerCell { get; set; }
    /// <summary> Opponent cell </summary>
    public OpponentCell OpponentCell { get; set; }

    #endregion

    #region Internal Methods

    /// <summary>
    /// Reads the current state of the world 
    /// </summary>
    /// <param name="file">Input for the sensor</param>
    /// <returns>True if the sensors could detect the world, false if something goes wrong</returns>
    internal bool LoadCurrentTurn(string[] world) {
      return CurrentTurn.BuildWorld(world);
    }

    /// <summary>
    /// Reads the last state of the world
    /// </summary>
    /// <param name="world">Last turn of the world</param>
    internal void LoadLastTurn(string[] world) {
      LastTurn.BuildWorld(world);
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// Event which is fired when the players last position is loaded
    /// </summary>
    /// <param name="playerCell">Player last turn position</param>
    private void LastTurn_LoadPlayerPositionEvent(PlayerCell playerCell) {
      PlayerCell.LastTurnPosition = playerCell;
    }

    /// <summary>
    /// Event which is fired when the opponents last position is loaded
    /// </summary>
    /// <param name="opponentCell">Opponent last turn position</param>
    private void LastTurn_LoadOpponentPositionEvent(OpponentCell opponentCell) {
      OpponentCell.LastTurnPosition = opponentCell;
    }

    private void CurrentTurn_LoadPlayerPositionEvent(PlayerCell playerCell) {
      Cell lastPosition = PlayerCell.LastTurnPosition;
      PlayerCell = playerCell;
      PlayerCell.LastTurnPosition = lastPosition;
      PlayerCell.DetermineFacing();
    }

    private void CurrentTurn_LoadOpponentPositionEvent(OpponentCell opponentCell) {
      Cell lastPosition = OpponentCell.LastTurnPosition;
      OpponentCell = opponentCell;
      OpponentCell.LastTurnPosition = lastPosition;
      OpponentCell.DetermineFacing();
    }

    #endregion
  }
}
