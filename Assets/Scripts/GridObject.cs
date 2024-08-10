using UnityEngine;

namespace GridSystem
{
    [System.Serializable]
    public class GridObject
    {
        public string Name;

        public int ID;

        public Vector2Int GridSize = Vector2Int.zero;

        public GameObject Prefab;
    }
}