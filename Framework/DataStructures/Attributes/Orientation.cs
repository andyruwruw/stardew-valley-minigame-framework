﻿using Microsoft.Xna.Framework;

namespace MinigameFramework.DataStructures.Attributes
{
    /// <summary>
    /// Polar coordinates for orientation of <see cref="Ball"/>.
    /// </summary>
    internal class Orientation
    {
        /// <summary>
        /// The circumference of the <see cref="Ball"/>.
        /// </summary>
        private float _circumference;

        /// <summary>
        /// Longitude and latitude degrees.
        /// </summary>
        private Vector2 _orientation;

        /// <summary>
        /// Instantiates a new orientation.
        /// </summary>
        /// <param name="radius">Radius of item.</param>
        /// <param name="longitude">Longitude of orientation.</param>
        /// <param name="latitude">Latitude of orientation.</param>
        public Orientation(
            float radius,
            float longitude = 0,
            float latitude = 0
        )
        {
            this._circumference = (float)(2 * Math.PI * radius);
            this._orientation = new Vector2(
                longitude,
                latitude
            );
        }

        /// <summary>
        /// Retrieves the simplified orientation.
        /// </summary>
        /// <returns>Longitude and latitude degrees</returns>
        public Vector2 GetFace()
        {
            float LATITUDE_DIFF = 30;

            float simplifiedLatitude = (float)Math.Round(this._orientation.Y / LATITUDE_DIFF) * LATITUDE_DIFF;

            float longitudeDiff = Math.Abs(simplifiedLatitude) != 60 ? 30 : 45;

            float simplifiedLongitude = (float)Math.Round(this._orientation.X / longitudeDiff) * longitudeDiff;

            return new Vector2(
                simplifiedLongitude == 180 ? 0 : simplifiedLongitude,
                simplifiedLatitude
            );
        }

        /// <summary>
        /// Retrieves the circumference of the <see cref="Ball"/>.
        /// </summary>
        /// <returns>The circumference of the <see cref="Ball"/></returns>
        public float GetCircumference()
        {
            return this._circumference;
        }

        /// <summary>
        /// Rotates the orientation based on velocity and circumference.
        /// </summary>
        /// <param name="velocity"></param>
        public void Roll(Vector2 velocity)
        {
            Vector2 degrees = new Vector2(
                velocity.X / this._circumference * 360,
                velocity.Y / this._circumference * 360
            );

            this._orientation = Vector2.Add(
                this._orientation,
                degrees
            );

            this.Limit();
        }

        /// <summary>
        /// Simplifies the orientation to not go above <c>180</c>.
        /// </summary>
        private void Limit()
        {
            float LATITUDE_DIFF = 30;
            float latitudeChanges = 0;
            float simplifiedLatitude = (float)Math.Round(this._orientation.Y / LATITUDE_DIFF) * LATITUDE_DIFF;

            while (simplifiedLatitude > 90)
            {
                simplifiedLatitude -= 180;
                latitudeChanges -= 180;
            }

            while (simplifiedLatitude < -90)
            {
                simplifiedLatitude += 180;
                latitudeChanges += 180;
            }

            float longitudeDiff = Math.Abs(simplifiedLatitude) != 60 ? 30 : 45;
            float longitudeChanges = 0;
            float simplifiedLongitude = (float)Math.Round(this._orientation.X / longitudeDiff) * longitudeDiff;

            float maxLongitude = Math.Abs(simplifiedLatitude) != 60 ? 150 : 135;

            while (simplifiedLongitude > maxLongitude)
            {
                simplifiedLongitude -= 180;
                longitudeChanges -= 180;
            }

            while (simplifiedLongitude <= 0)
            {
                simplifiedLongitude += 180;
                longitudeChanges += 180;
            }

            if (latitudeChanges != 0 || longitudeChanges != 0)
            {
                this._orientation = new Vector2(this._orientation.X + longitudeChanges, this._orientation.Y + latitudeChanges);
            }
        }
    }
}
