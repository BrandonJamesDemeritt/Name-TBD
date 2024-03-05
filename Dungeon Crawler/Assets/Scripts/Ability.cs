using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private ParticleSystem particleSystem; //The particle system that the script controls

    public ParticleSystem GetParticleSystem()
    {
        return particleSystem;
    }//end GetParticleSystem

    public void SetParticleSystem(ParticleSystem newParticleSystem)
    {
        particleSystem = newParticleSystem;
    }//end SetParticleSystem

    // Start is called before the first frame update
    void Start()
    {
        //We call the particle system here, so that we can use it in scripting
        particleSystem = GetComponent<ParticleSystem>();

        //Make sure the particle system isn't active when the scene is started
        particleSystem.Stop();

    }//end start

    /*
        Checks to see if the particle collides with an object and then performs an action in the game depending on specific tags
        @param other: the GameObject that the particle collides with
    */
    private void OnParticleCollision(GameObject other)
    {
        //Destroying an object that is flammable
        //Give any objects that you want destroyed by fire the "flammable" tag
        if (other.tag == "flammable" && this.tag == "fire")
        {
            Destroy(other, 3f); //Destroy after 3 seconds
        }//end if

        //This is for certain objects that are affected by wind, but not able to be moved... such as a lever
        if (other.tag == "AffectedByWind" && this.tag == "wind")
        {
            //Not implemented yet
        }//end if
    }

}
