using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Movement
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private Vector3 lastPosition;

        [SerializeField] private LayerMask placementLayerMask;

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
