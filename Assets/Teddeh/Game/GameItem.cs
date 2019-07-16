using UnityEngine;
using System;

namespace Teddeh.Game
{
    
    public interface GameItem
    {
        /**
         * DESIGN NOTES
         *
         * Identifier - Unique identifier
         * 
         * Mesh Object - model of item if suitable
         * Material - texture needed if suitable
         * Mesh Scale - sizing of mesh item
         * Mesh Collision - collision option
         *
         * more?
         */

        int GetUniqueIdentifier();

        GameObject GetMeshObject();

        Material GetMeshMaterial();

        float GetMeshScale();

        bool HasMeshCollision();
    }
}