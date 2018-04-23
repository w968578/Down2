using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex {
    // q+r+s = 0
    // s = -(q+r)
    /// <summary>
    ///  Q, R, and S are ints based on tile position
    ///  column, row, and inverse sum respectively.
    ///  see above equations
    /// </summary>
	public readonly int Q;
    public readonly int R;
    public readonly int S;

    readonly float WIDTH_MULT = Mathf.Sqrt(3) / 2f;

    bool allowEastWestWrap = true;
    bool allowNorthSouthWrap = true;

    // Radius for each hex tile - hardcoded for the moment.
    static float radius = 1f;
    public Hex(int q, int r)
    {
        this.Q = q;
        this.R = r;
        this.S = -(q + r);
    }
    public Vector3 Position()
    {
        
        float horizontal = getWidth();
        float vertical = .75f * getHeight();

        return new Vector3(
            horizontal * (this.Q + this.R / 2f),
            0,
            vertical * this.R
        );
    }

    public float getHeight()
    {
        return radius * 2f;
    }
    public float getWidth()
    {
        return getHeight() * WIDTH_MULT;
    }
    public float hexVertSpace()
    {
        return getHeight() * .75f;
    }
    public float hexHorizSpace()
    {
        return getWidth();
    }
    public Vector3 PositionFromCamera( Vector3 cameraPosition, float rows, float cols)
    {
        float mapHeight = rows * hexVertSpace();
        float mapWidth = cols * hexHorizSpace();

        Vector3 position = Position();
        // allowEastWestWrap default value is true
        if (allowEastWestWrap) { 
            float xDist_from_camera = (position.x - cameraPosition.x) / mapWidth;

            if (xDist_from_camera > 0)
            {
                xDist_from_camera += 0.5f;
            }
            else
                xDist_from_camera -= 0.5f;

            int xDist_correction = (int)xDist_from_camera;
            position.x -= xDist_correction * mapWidth;
        }
        // allowNorthSouthWrap in normal games is false, here it is true
        if (allowNorthSouthWrap) {
            float zDist_from_camera = (position.z - cameraPosition.z) / mapHeight;

            if (zDist_from_camera > 0)
            {
                zDist_from_camera += 0.5f;
            }
            else
                zDist_from_camera -= 0.5f;

            int zDist_correction = (int)zDist_from_camera;
            position.z -= zDist_correction * mapHeight;
        }

        return position;
    }
}
