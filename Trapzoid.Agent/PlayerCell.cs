
namespace Trapzoid.Agent {
    
  /// <summary>
  /// Player cell
  /// </summary>
  public class PlayerCell : Cell {
    #region Properties

    /// <summary> Indicates the facing of the Player </summary>
    public Facings Facing { get; set; }
    public Cell North { get; set; }
    public Cell East { get; set; }
    public Cell South { get; set; }
    public Cell West { get; set; }

    #endregion

    #region Public Methods

    #endregion
  }
}
