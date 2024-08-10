using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Movement
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private GameObject mouseIndicator;
        [SerializeField] private GameObject cellIndicator;

        [SerializeField] private InputManager inputManager;

        [SerializeField] private Grid grid;

        private void Update()
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            mouseIndicator.transform.position = mousePosition;
            cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        }
    }
}