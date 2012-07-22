
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
    /// <summary> World state for the sensor </summary>
    public World World { get; private set; }
    #endregion

    #region Public Variables
    /// <summary>
    /// Reads the current state of the world 
    /// </summary>
    /// <param name="file">Input for the sensor</param>
    /// <returns>True if the sensors could detect the world, false if something goes wrong</returns>
    public bool Sense(string[] world) {
      World = new World();
      return World.BuildWorld(world);      
    }
    #endregion
  }
}
