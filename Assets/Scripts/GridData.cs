using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class GridData
    {
        private Dictionary<Vector3Int, PlacementData> placedObjects = new();
        public Dictionary<Vector3Int, PlacementData> PlacedObjects { get => placedObjects; set => placedObjects = value; }

        public void AddObjectsAt(Vector3Int gridPosition, Vector2Int objectGridSize, int objectID, int placedObjectedIndex)
        {
            List<Vector3Int> posotionsOccupied = CalculateObjectGrisPositions(gridPosition, objectGridSize);
            PlacementData newData = new PlacementData(posotionsOccupied, objectID, placedObjectedIndex);

            foreach (var position in posotionsOccupied)
            {
                if (placedObjects.ContainsKey(position))
                    throw new Exception("Dict already contains this cell position " + position);
                placedObjects[position] = newData;
            }
        }

        private List<Vector3Int> CalculateObjectGrisPositions(Vector3Int gridPosition, Vector2Int objectGridSize)
        {
            List<Vector3Int> positions = new();
            for (int x = 0; x < objectGridSize.x; x++)
            {
                for (int y = 0; y < objectGridSize.y; y++)
                {
                    positions.Add(gridPosition + new Vector3Int(x, 0, y));
                }
            }
            return positions;
        }

        public bool CanPlaceObjectsAt(Vector3Int gridPosition, Vector2Int objectGridSize)
        {
            List<Vector3Int> positions = CalculateObjectGrisPositions(gridPosition, objectGridSize);
            foreach (var position in positions)
            {
                if (placedObjects.ContainsKey(position))
                    return false;
            }
            return true;
        }
    }
}

public class PlacementData
{
    public List<Vector3Int> occupiedGridPositions;
    public int ID { get; private set; }
    public int PlacedObjectIndex { get; private set; }

    public PlacementData(List<Vector3Int> occupiedGridPositions, int iD, int placedObjectIndex)
    {
        this.occupiedGridPositions = occupiedGridPositions;
        ID = iD;
        PlacedObjectIndex = placedObjectIndex;
    }
}