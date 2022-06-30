using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    
    public bool check;
    
    List<GameObject> listOfObj=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        check = true;
    
    }

    private void Update()
    {
        print(listOfObj.Count);
    }

    private void OnMouseDown()
    {
        CheckAdjacent();  // check ajdacnt cubes
       // StartCoroutine(DelayDeactivate());
    }

    public void CheckAdjacent()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.right,out hit,.4f))  //for right
        {
            listOfObj.Add(hit.transform.gameObject);     
        }
        if (Physics.Raycast(transform.position, -transform.right, out hit, .4f))  //for left
        {
            listOfObj.Add(hit.transform.gameObject);
        }
        if (Physics.Raycast(transform.position, transform.up, out hit, .4f))  //for top
        {
            listOfObj.Add(hit.transform.gameObject);
        }
        if (Physics.Raycast(transform.position, -transform.up, out hit, .4f))  //for down
        {
            listOfObj.Add(hit.transform.gameObject);
        }


        if (listOfObj.Count > 0)
        {
            foreach (GameObject obj in listOfObj)
            {
                Deactivate(obj);
            }
        }
    }
 

    void Deactivate(GameObject obj)
    {
        var temp = obj.GetComponent<Box>();

        if (temp.check)
        {
            temp.CheckAdjacent();

            temp.check = false;   //hit object so it doesnt do multiple raycast
        }

        if (obj.CompareTag("Player"))
        {
            obj.SetActive(false);   //deactivate hit objects
        }       
    }

    //IEnumerator DelayDeactivate()
    //{
    //    yield return new WaitForSeconds(0);
    //    gameObject.SetActive(false);
    //} 
}
