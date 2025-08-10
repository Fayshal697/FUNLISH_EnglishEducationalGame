using UnityEngine;

[System.Serializable]
public class ObjectiveData {
    public string id;
    public string description;
    [HideInInspector] public bool isComplete = false;
}
