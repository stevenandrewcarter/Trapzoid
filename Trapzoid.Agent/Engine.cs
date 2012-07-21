using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public Sensor Sensor { get; private set; }
    #endregion
  }
}