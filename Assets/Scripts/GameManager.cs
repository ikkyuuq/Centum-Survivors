// 15 lines
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float progressionInterval = 5f,
        speedIncrease = 0.5f,
        progressionTimer = 0f;

    void Start() { }

    void Update()
    {
        HandleProgression();
    }

    void HandleProgression()
    {
        progressionTimer += Time.deltaTime;
        if (progressionTimer >= progressionInterval)
        {
            progressionTimer = 0;
        }
    }
}
