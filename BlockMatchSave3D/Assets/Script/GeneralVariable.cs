using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralVariable : MonoBehaviour
{
    public static GeneralVariable instance;

    public GameObject BlueParticle;
    public GameObject redParticle;
    public GameObject greenParticle;
    public GameObject yellowParticle;

    private void Start()
    {
        instance = this;
    }
}
