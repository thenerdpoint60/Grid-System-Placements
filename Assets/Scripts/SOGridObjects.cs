using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    [CreateAssetMenu(fileName = "Grid Objects", menuName = "ScriptableObjects/Grid Objects", order = 1)]
    public class SOGridObjects : ScriptableObject
    {
        public List<GridObject> gridObjects;
    }
}