using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  

    public GameObject SkeletonSwordsman;

    private void Start()
    {
        spawnenemy();
    }

    public void spawnenemy()
    {

        GameObject ClonedSkeletonSwordsman;
        ClonedSkeletonSwordsman = Instantiate(SkeletonSwordsman);
        ClonedSkeletonSwordsman.transform.position = transform.position;

        Rigidbody2D ClonedSkeletonSwordsmanBody;
        ClonedSkeletonSwordsmanBody = ClonedSkeletonSwordsman.GetComponent<Rigidbody2D>();
    }


}
