using UnityEngine;

public class Simulation : MonoBehaviour
{
    private float timer;
    void Start()
    {
        Physics.autoSimulation = false;
    }

    void Update()
    {
        if (Physics.autoSimulation)
            return; // do nothing if the automatic simulation is enabled

        timer += Time.deltaTime;

        // Catch up with the game time.
        // Advance the physics simulation in portions of Time.fixedDeltaTime
        // Note that generally, we don't want to pass variable delta to Simulate as that leads to unstable results.
        while (timer >= Time.fixedDeltaTime)
        {
            timer -= Time.fixedDeltaTime;
            Physics.Simulate(Time.fixedDeltaTime);
        }

        // Here you can access the transforms state right after the simulation, if needed
    }
}
