using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private GameObject mouseIndicator;
        [SerializeField] private GameObject cellIndicator;

        [SerializeField] private InputManager inputManager;

        [SerializeField] private Grid grid;

        [SerializeField] private SOGridObjects gridObjectsDatabase;
        private int selectedObjectedIndex = -1;

        private void Start()
        {
            StopPlacements();
            selectedObjectedIndex = 0;
        }

        private void OnEnable()
        {
            inputManager.OnMouseClicked += PlaceStructure;
        }

        private void OnDisable()
        {
            inputManager.OnMouseClicked -= PlaceStructure;
        }

        public void StartPlacement(int objectID)
        {
            selectedObjectedIndex = gridObjectsDatabase.gridObjects.FindIndex(data => data.ID == objectID);

            if (selectedObjectedIndex < 0)
            {
                Debug.Log("No Object ID found " + objectID);
                return;
            }
        }

        private void PlaceStructure()
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            GameObject gridObject = Instantiate(gridObjectsDatabase.gridObjects[selectedObjectedIndex].Prefab);
            gridObject.transform.position = grid.CellToWorld(gridPosition);
        }

        private void StopPlacements()
        {

        }

        private void Update()
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);
            mouseIndicator.transform.position = mousePosition;
            cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        }
    }
}