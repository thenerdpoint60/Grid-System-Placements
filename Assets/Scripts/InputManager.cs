using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private Vector3 lastPosition;

        [SerializeField] private LayerMask placementLayerMask;

        public event Action OnMouseClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClicked?.Invoke();
            }
        }

        public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();

        public Vector3 GetSelectedMapPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.nearClipPlane;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
            {
                lastPosition = hit.point;
            }
            return lastPosition;
        }
    }
}
