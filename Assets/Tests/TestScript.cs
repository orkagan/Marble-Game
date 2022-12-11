using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    GameObject _gameGO;

    [SetUp]
    public void Setup()
    {
        _gameGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game World"));
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_gameGO);
    }
    
    //test that the marble does not go below -17f which is where the death zone should be to delete it
    [UnityTest]
    public IEnumerator BelowDeathZone()
    {
        Rigidbody marble = MonoBehaviour.FindObjectOfType<Rigidbody>();
        yield return new WaitForSeconds(15f);
        Assert.IsFalse(marble.transform.position.y < -17f);
    }

    //test that the marble is falling by checking if its original position is higher than pos after 0.1 seconds
    [UnityTest]
    public IEnumerator MarbleFalls()
    {
        Rigidbody marble = MonoBehaviour.FindObjectOfType<Rigidbody>();
        float yPos = marble.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(marble.transform.position.y, yPos);
    }
}
