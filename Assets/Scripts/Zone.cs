using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract means, we can't create a instance/component of this class
public abstract class Zone : MonoBehaviour
{
    //code for this function is written in child/derived classes
    protected abstract void ZoneTrigger(GameObject marble);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marble")
        {
            ZoneTrigger(other.gameObject);
        }
    }

    protected IEnumerator DissableWithDelay(GameObject go, float delay = 1)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
