using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Bird> Birds;
    void Start()
    {
        SlingShooter.InitiateBird(Birds[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
