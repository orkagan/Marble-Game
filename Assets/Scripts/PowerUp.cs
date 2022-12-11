using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Zone
{
    bool _isDeactivating = false; //bool to check if its already in the process of deactivating
    public float maxSpinSpeed = 300f; //max spin speed
    public float spinRate = 1000f; //spin acceleration/deceleration rate
    float _spinSpeed;
    private void Start()
    {
        _spinSpeed = maxSpinSpeed;
    }
    private void Update()
    {
        transform.Rotate(0f, _spinSpeed * Time.deltaTime, 0f, Space.World);
    }
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
            StartCoroutine(Spin());
            yield return new WaitForSeconds(delay);

            //disable
            go.GetComponent<MeshRenderer>().enabled = false;
            go.GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(returnDelay);

            //reenable
            go.GetComponent<MeshRenderer>().enabled = true;
            go.GetComponent<Collider>().enabled = true;
            _isDeactivating = false;
            StartCoroutine(Spin());
        }
    }
    protected IEnumerator Spin()
    {
        //slowing down if deactivating
        while (_isDeactivating&&_spinSpeed>0)
        {
            _spinSpeed -= spinRate*Time.deltaTime;
            yield return null;
        }
        //speeding up if activated
        while (!_isDeactivating&&_spinSpeed<maxSpinSpeed)
        {
            _spinSpeed += spinRate*Time.deltaTime;
            yield return null;
        }
    }
}
