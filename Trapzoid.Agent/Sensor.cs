using System.IO;

namespace Trapzoid.Agent {
  
  /// <summary>
  /// Internal States of the world
  /// </summary>
  public enum WorldState {
    Empty = 0,
    Wall = 1,
    Player = 2,
    Enemy = 3
  }

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
    public World World { get; private set; }
    #endregion

    #region Public Variables
    /// <summary>
    /// Reads the current state of the world 
    /// </summary>
    /// <param name="file">Input for the sensor</param>
    /// <returns>True if the sensors could detect the world, false if something goes wrong</returns>
    public bool Sense(string[] world) {
      World = new World(world);
      return true;
    }
    #endregion
  }
}
