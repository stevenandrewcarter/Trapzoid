
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
      Sensor.Sense(world);
    }
    #endregion

    #region Properties
    /// <summary> Sensor for the agent </summary>
    public Sensor Sensor { get; private set; }
    #endregion

    #region Public Methods
    /// <summary>
    /// Processes the turn for the agent
    /// </summary>
    /// <returns>The state that the world will for the turn</returns>
    public World Process() {
      return Sensor.World;
    }
    #endregion
  }
}