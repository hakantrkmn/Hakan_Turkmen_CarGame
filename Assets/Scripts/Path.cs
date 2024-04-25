using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace CarGame
{
    public class Path : MonoBehaviour
    {
        public PathStates state;
        public Transform entrance;

        public Transform target;

        [Range(3, 15)] public float thickness = 5;


        public Car car;

        public void Passed()
        {
            state = PathStates.Passed;
            car = car.AddComponent<DummyCar>();
            Destroy(car.GetComponent<PlayerCar>());
            Destroy(car.GetComponent<Movement>());

            car.path = this;
            (car as DummyCar).Set();
            (car as DummyCar).Reset();
        }
        
   
        
        private void OnDrawGizmos()
        {
            if (Selection.Contains(gameObject) || Selection.Contains(entrance.gameObject) || Selection.Contains(target.gameObject) || Selection.Contains(transform.root.gameObject))
            {
                var startPos = entrance.position;
                var endPos = entrance.position + (entrance.forward * 10);

                Handles.color = Color.blue;
                Handles.DrawLine(startPos, endPos, thickness);
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.yellow;
                Handles.Label(entrance.position, "Entrance",style);
                style.normal.textColor = Color.red;
                Handles.Label(target.position, "Target",style);
                Handles.Label(endPos, "Car direction");
                Gizmos.DrawCube(target.position,Vector3.one*2);
                Gizmos.DrawCube(entrance.position,Vector3.one*2);

            }
        }
    }
}