using Microsoft.Xna.Framework;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Various vector math.
    /// </summary>
    internal class Vectors
    {
        /// <summary>
        /// Returns the magnitude of a <see cref="Vector"/>
        /// </summary>
        /// <param name="vector"><see cref="Vector2"/> in question</param>
        /// <returns>Magnitude of <see cref="Vector2"/></returns>
        public static float GetMagnitude(Vector2 vector)
        {
            return (float)Math.Sqrt(Math.Pow(
                    vector.X,
                    2
                ) + Math.Pow(
                    vector.Y,
                    2
                )
            );
        }

        /// <summary>
        /// Converts <see cref="Vector2"/> to radians.
        /// </summary>
        /// <param name="angle"><see cref="Vector2"/> value to convert</param>
        /// <returns>Value as radians</returns>
        public static float VectorToRadians(Vector2 angle)
        {
            return (float)Math.Atan2(
                angle.Y,
                angle.X
            );
        }
    }
}
