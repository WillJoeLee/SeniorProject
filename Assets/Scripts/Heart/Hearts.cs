using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public int trueDeath = 0;
    public GameObject loseInform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trueDeath == 4)
        {
            if (loseInform.TryGetComponent<GameEnd>(out GameEnd ohnoes))
            {
                ohnoes.loseGame = true;
            }
        }
    }
}
