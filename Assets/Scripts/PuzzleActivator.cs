using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivator : MonoBehaviour
{
    public float timeToActivate;
    public float timeToDeactivate;
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    private void OnEnable()
    {
        if(objectsToActivate != null)
            StartCoroutine(SetActivationWithTime(objectsToActivate, true, timeToActivate));

        if(objectsToDeactivate != null)
            StartCoroutine(SetActivationWithTime(objectsToDeactivate, false, timeToDeactivate));
    }

    private void OnDisable()
    {
        SetActivation(objectsToDeactivate, false);
    }

    public void SetActivation(List<GameObject> objList, bool val)
    {
        foreach (var obj in objList)
        {
            obj.SetActive(val);
        }
    }

    public IEnumerator SetActivationWithTime(List<GameObject> objList, bool val, float timeToSetActivation)
    {
        yield return new WaitForSeconds(timeToSetActivation);
        foreach (var obj in objList)
        {
            obj.SetActive(val);
        }
    }
}
