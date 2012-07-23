using System;

namespace Trapzoid.Agent {
    
  /// <summary>
  /// Cell which the player contains
  /// </summary>
  public class PlayerCell : LightCycleCell, IComparable {

    public int CompareTo(object obj) {
      return base.CompareTo(obj);
    }
  }
}
