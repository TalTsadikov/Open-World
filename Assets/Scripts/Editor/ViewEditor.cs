using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class ViewEditor : Editor
{
    private void OnSceneGUI()
    {
        Character fow = (Character)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.AttackRange);
        
    }
}