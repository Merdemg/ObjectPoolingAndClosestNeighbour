using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestNeighbour : MonoBehaviour
{
    [SerializeField] static List<FindNearestNeighbour> allCopies = new List<FindNearestNeighbour>();
    FindNearestNeighbour nearestNeighbour = null;
    float nearestNeighbourDistance = float.MaxValue;


    delegate void NewNeighbour(FindNearestNeighbour NewNeignour);

    static NewNeighbour newNeighbour;
    
    delegate void NeighbourDisabled(FindNearestNeighbour DisabledNeignour);

    static NeighbourDisabled neighbourDisabled;

    // Start is called before the first frame update
    void OnEnable()
    {
        allCopies.Add(this);
        Find();
        newNeighbour += HandleNewNeighbour;
        newNeighbour?.Invoke(this);
        neighbourDisabled += HandleDisabledNeighbour;
    }

    void OnDisable(){
        allCopies.Remove(this);
        nearestNeighbour = null;
        newNeighbour -= HandleNewNeighbour;
        neighbourDisabled -= HandleDisabledNeighbour;
        neighbourDisabled?.Invoke(this);
    }

    FindNearestNeighbour Find(){
        nearestNeighbour = null;
        nearestNeighbourDistance = float.MaxValue;

        if (allCopies.Count > 1)
        {
            foreach (FindNearestNeighbour neighbour in allCopies)
            {
                float Distance = Vector3.Distance(transform.position, neighbour.transform.position);
                if (neighbour != this && Distance < nearestNeighbourDistance)
                {
                    nearestNeighbourDistance = Distance;
                    nearestNeighbour = neighbour;
                }
            }
            Debug.Log("I am " + gameObject.name + "and my nearest neighbour is: " + nearestNeighbour.gameObject.name);
        }

        return nearestNeighbour;
    }

    void HandleNewNeighbour(FindNearestNeighbour NewNeighbour){
        if (this != NewNeighbour)
        {
            float Distance = Vector3.Distance(transform.position, NewNeighbour.transform.position);
            if (Distance < nearestNeighbourDistance)
            {
                nearestNeighbourDistance = Distance;
                nearestNeighbour = NewNeighbour;
                Debug.Log("I am " + gameObject.name + "and my new nearest neighbour is: " + nearestNeighbour.gameObject.name);
            }
        }
    }

    void HandleDisabledNeighbour(FindNearestNeighbour DisabledNeighbour){
        if (DisabledNeighbour == nearestNeighbour)
        {
            Find();
        }
    }
}
