
namespace Trapzoid {

  /// <summary>
  /// Represents the world
  /// </summary>
  public class World {
    #region Private variables
    /// <summary> Represents the world </summary>
    private float[,] world;
    private int width;
    private int height;
    #endregion

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="newWidth">Width of the world</param>
    /// <param name="newHeight">Height of the world</param>
    public World(string[] world) {
      BuildWorld(world);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Builds the world from the input given as a string
    /// </summary>
    /// <param name="newWorld"></param>
    /// <returns></returns>
    private bool BuildWorld(string[] newWorld) {
      bool builtWorld = false;
      if (newWorld.Length > 0) {
        width = newWorld[0].Split(' ').Length;
        height = newWorld.Length;
        world = new float[width, height];
        builtWorld = true;
      }
      return builtWorld;
    }

    /// <summary>
    /// Override the ToString method of base Object class
    /// </summary>
    /// <returns>A string representation of the world</returns>
    public override string ToString() {
      var returnString = "";
      for (var i = 0; i < width; i++) {
        for (var j = 0; j < height; j++) {
          returnString += world[i, j].ToString();
        }
        returnString += "\n\r";
      }
      return returnString;
    }
    #endregion
  }
}
