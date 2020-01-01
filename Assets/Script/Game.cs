using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Game : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Awake()
    {
        _InitializeServices();
    }

    public void _InitializeServices()
    {
        ServiceLocator._game = this;
        ServiceLocator._dialogManager = gameObject.GetComponent<DialogManager>();
        ServiceLocator._audioManager = gameObject.GetComponent<AudioManager>();
        ServiceLocator._gameState = gameObject.GetComponent<GameState>();
        ServiceLocator._flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

}
