using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapRaycast
{
    public static Vector3 ProjectPointOntoTilemapPlane(Tilemap tilemap, Vector3 worldPoint)
    {
        Transform t = tilemap.transform;

        // Plane that goes through the tilemap origin, with normal pointing out of the tilemap
        Plane plane = new Plane(t.forward, t.position);

        Vector3 rayDireciton = Camera.main.transform.forward;

        // Cast a ray along the plane normal (either direction works)
        Ray ray = new Ray(worldPoint - rayDireciton * 1000f, rayDireciton);

        if (plane.Raycast(ray, out float enter))
            return ray.GetPoint(enter);

        return worldPoint; // fallback (should rarely happen)
    }
}
