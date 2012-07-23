
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
    }

    #endregion

    #region Properties

    /// <summary> Current state of the world </summary>
    public World CurrentTurn { get; private set; }
    /// <summary> Last state of the world </summary>
    public World LastTurn { get; private set; }

    #endregion

    #region Internal Methods

    /// <summary>
    /// Reads the current state of the world 
    /// </summary>
    /// <param name="file">Input for the sensor</param>
    /// <returns>True if the sensors could detect the world, false if something goes wrong</returns>
    internal bool LoadCurrentTurn(string[] world) {
      CurrentTurn = new World();
      return CurrentTurn.BuildWorld(world);      
    }

    /// <summary>
    /// Reads the last state of the world
    /// </summary>
    /// <param name="world">Last turn of the world</param>
    internal void LoadLastTurn(string[] world) {
      LastTurn = new World();
      LastTurn.BuildWorld(world);
    }

    #endregion    
  }
}
