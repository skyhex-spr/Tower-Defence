using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public Waves WavesData;

    [Header("Enemy Start Postions")]
    public List<Transform> StartPositions;
    


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        WaveManager.instance.StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
