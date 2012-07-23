using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trapzoid.Agent {
  public class LightCycleCell : Cell, IComparable {
    
    #region Properties

    /// <summary> Indicates the facing of the Player </summary>
    public Facings Facing { get; set; }
    /// <summary> Cell North of the player position </summary>
    public Cell North { get; set; }
    /// <summary> Cell East of the player position </summary>
    public Cell East { get; set; }
    /// <summary> Cell South of the player position </summary>
    public Cell South { get; set; }
    /// <summary> Cell West of the player position </summary>
    public Cell West { get; set; }
    /// <summary> Position the player was in last </summary>
    public Cell LastTurnPosition { get; set; }

    #endregion

    #region Public Methods

    internal void DetermineFacing() {
      if (LastTurnPosition.CompareTo(North) == 0) {
        Facing = Facings.South;
      } else if (LastTurnPosition.CompareTo(South) == 0) {
        Facing = Facings.North;
      } else if (LastTurnPosition.CompareTo(East) == 0) {
        Facing = Facings.West;
      } else {
        Facing = Facings.East;
      }
    }

    public int CompareTo(object obj) {
      return base.CompareTo(obj);
    }

    #endregion

  }
}
