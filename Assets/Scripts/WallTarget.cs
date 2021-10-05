using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform player;
    private int sizeList;
    [SerializeField]
    private ScoreManager scoreManager;
    void Start()
    {
        sizeList = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sizeList == 4)
            return;
        
        Vector3 noise = 2.0f * (new Vector3(15.5f, UnityEngine.Random.Range(0, 4f), UnityEngine.Random.Range(-4f, 4f)));
        Instantiate(target, player.transform.position + noise - player.transform.position.x*Vector3.right, Quaternion.identity);
        sizeList++;
    }

    public void destroyTarget() {
        sizeList--;
        scoreManager.incrementScore();
    }
}
