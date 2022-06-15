using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour  //INHERITANCE
{
    [SerializeField] private LayerMask layerMask;

    // Update is called every frame;
    void Update()  //INHERITED ABSTRACTION
    {
        // pressing the right moust button does stuff
        if (Mouse.current.rightButton.wasPressedThisFrame)
            Click();  //ABSTRACTION
    }

    // stuff right mouse button does
    void Click()  //ABSTRACTION
    {
        // prepare raycast from mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();  //ABSTRACTION
        Ray ray = Camera.main.ScreenPointToRay(mousePos);  //ABSTRACTION
        RaycastHit hit;

        // cast ray from mouse position only allowing hits to enemy and ground layers as set in Unity Editor, you hope
        if(Physics.Raycast(ray, out hit, 999, layerMask))  //ABSTRACTION
        {
            // determine layer hit by raycast essentially determining if raycast hit an enemy or the ground
            int hitLayer = hit.collider.gameObject.layer;

            // if raycast hit the ground move to that spot else if raycast hit an enemy move to that enemy and prepare for battle
            if(hitLayer == LayerMask.NameToLayer("Ground"))  //ABSTRACTION
            {
                Player.Current.SetTarget(null);  //ABSTRACTION
                Player.Current.Controller.MoveToPosition(hit.point);  //ABSTRACTION
            }
            else if(hitLayer == LayerMask.NameToLayer("Enemy"))  //ABSTRACTION
            {
                Character enemy = hit.collider.GetComponent<Character>();  //ABSTRACTION
                Player.Current.SetTarget(enemy);  //ABSTRACTION
            }
        }
    }
}
