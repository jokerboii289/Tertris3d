using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTwo : MonoBehaviour
{
    private int childCount;
    private bool canDestroy;
    
    private void OnMouseDown()
    {
        CheckTheSideCubes();
        if (canDestroy)// destroy cube
        {
            CharacterNPC.instance.Jump();
            var root = transform.root;
            Effect(transform.root);
            childCount = root.childCount;
            //print(childCount);
            GameObject[] listOfCubes = new GameObject[childCount];
            for (int i = 0; i < listOfCubes.Length; i++)
            {
                listOfCubes[i] = root.GetChild(i).gameObject;
            }

            foreach (GameObject obj in listOfCubes)
            {
                obj.SetActive(false);
            }
        }
    }

    void Effect(Transform obj)
    {
        if(obj.tag=="blue")
            Instantiate(GeneralVariable.instance.BlueParticle, transform.position, Quaternion.identity);
        else if(obj.tag == "red")
            Instantiate(GeneralVariable.instance.redParticle, transform.position, Quaternion.identity);
        else if (obj.tag == "green")
            Instantiate(GeneralVariable.instance.greenParticle, transform.position, Quaternion.identity);
        else if (obj.tag == "yellow")
            Instantiate(GeneralVariable.instance.yellowParticle, transform.position, Quaternion.identity);
    }

    void CheckTheSideCubes()
    {
        List<GameObject> listOfObj = new List<GameObject>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, .4f))  //for right
        {
            //listOfObj.Add(hit.transform.gameObject);
            AddToList(hit.transform.gameObject);
        }
        if (Physics.Raycast(transform.position, -transform.right, out hit, .4f))  //for left
        {
            AddToList(hit.transform.gameObject);
        }
        if (Physics.Raycast(transform.position, transform.up, out hit, .4f))  //for top
        {
            AddToList(hit.transform.gameObject);
        }
        if (Physics.Raycast(transform.position, -transform.up, out hit, .4f))  //for down
        {
            AddToList(hit.transform.gameObject);
        }

        if(listOfObj.Count<1)
        {
            print("cant Destroy");
            canDestroy = false;
        }
        else if(listOfObj.Count>=1)
        {            
            canDestroy = true;
            //foreach (GameObject obj in listOfObj)
            //{
                
            //}
        }
        void AddToList(GameObject obj)
        {
            if(obj.CompareTag("cube") && obj.transform.root.CompareTag(transform.root.tag))//check its a cube and belongs to same tag group
                listOfObj.Add(obj);
            
        }
    }

    
    
}
