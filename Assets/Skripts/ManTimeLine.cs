using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManTimeLine : MonoBehaviour
{
    public Rigidbody body;
    public GameObject man;

    private void Start()
    {
        body = GetComponent<Rigidbody>();   
    }

    public void SizeMan()
    {
        man.transform.localScale = new Vector3(2, 3, 2);
    }

    //мен€ю массу
    public void PowerMan()
    {
        body.mass = 10;
    }

    public void DeathMan()
    {
        Destroy(man);
    }
}
