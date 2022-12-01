using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Zone
{
    bool _isDeactivating = false;
    protected abstract void PowerUpActivate(GameObject marble);
    
    protected override void ZoneTrigger(GameObject marble)
    {
        if (!_isDeactivating)
        {
            StartCoroutine(DissableWithDelay(gameObject, 1f, 3f));
        }
        PowerUpActivate(marble);
    }

    protected IEnumerator DissableWithDelay(GameObject go, float delay = 1, float returnDelay = 3)
    {
        if (!_isDeactivating)
        {
            _isDeactivating = true;
            yield return new WaitForSeconds(delay);
            go.GetComponent<MeshRenderer>().enabled = false;
            go.GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(returnDelay);
            go.GetComponent<MeshRenderer>().enabled = true;
            go.GetComponent<Collider>().enabled = true;
            _isDeactivating = false;
        }
    }
}
