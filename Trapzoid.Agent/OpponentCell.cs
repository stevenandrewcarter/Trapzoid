using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trapzoid.Agent {

  /// <summary>
  /// Cell which represents the opponent
  /// </summary>
  public class OpponentCell : LightCycleCell, IComparable {

    public int CompareTo(object obj) {
      return base.CompareTo(obj);
    }
  }
}
