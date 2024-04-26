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
        public Transform entrance;

        public Transform target;

        [Range(3, 15)] public float thickness = 7;


        public Car car;

        private void OnValidate()
        {
            ConfigureUI();
        }

        public void Passed()
        {
            car = car.AddComponent<DummyCar>();

            Destroy(car.GetComponent<PlayerCar>());
            Destroy(car.GetComponent<Movement>());
            Destroy(car.GetComponent<CarInteraction>());

            car.path = this;
            (car as DummyCar)?.Set();
            (car as DummyCar)?.Reset();
        }

        public void ToggleCanvas(bool isOn)
        {
            entrance.gameObject.SetActive(isOn);
            target.gameObject.SetActive(isOn);
        }

        void ConfigureUI()
        {
            var entranceCanvas = entrance.GetChild(0).transform;
            entranceCanvas.up = entrance.forward;
            entranceCanvas.localRotation = Quaternion.Euler(new Vector3(90, entranceCanvas.localRotation.eulerAngles.y,
                entranceCanvas.localRotation.eulerAngles.z));
        }
        
   
        
        private void OnDrawGizmos()
        {
            if (Selection.Contains(gameObject) || Selection.Contains(entrance.gameObject) || Selection.Contains(target.gameObject) )
            {
                var startPos = entrance.position;
                var endPos = entrance.position + (entrance.forward * 10);

                Handles.color = Color.blue;
                Handles.DrawLine(startPos, endPos, thickness);
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.red;
                Handles.Label(endPos, "Car direction",style);
                
                 startPos = target.position;
                 endPos = target.position + ((-target.position + entrance.position).normalized * 10);

                Handles.color = Color.blue;
                Handles.DrawLine(startPos, endPos, thickness);
                /*Gizmos.DrawCube(target.position,Vector3.one*2);
                Gizmos.DrawCube(entrance.position,Vector3.one*2);
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.yellow;
                Handles.Label(entrance.position, "Entrance",style);
                style.normal.textColor = Color.red;
                Handles.Label(target.position, "Target",style);
                */

            }
        }
    }
}