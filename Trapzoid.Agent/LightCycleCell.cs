using System;

namespace Trapzoid.Agent {

  /// <summary>
  /// Cell which represents a light cycle
  /// </summary>
  public class LightCycleCell : Cell {
    
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

    /// <summary>
    /// Determines the facing of the light cycle
    /// </summary>
    public void DetermineFacing() {
      if (LastTurnPosition != null) {
        if (LastTurnPosition.CompareTo(North) == 0) {
          North.Value = 0;
          Facing = Facings.South;
        } else if (LastTurnPosition.CompareTo(South) == 0) {
          South.Value = 0;
          Facing = Facings.North;
        } else if (LastTurnPosition.CompareTo(East) == 0) {
          East.Value = 0;
          Facing = Facings.West;
        } else {
          West.Value = 0;
          Facing = Facings.East;
        }
      }
    }

    #endregion
  }
}
