using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject fourthCube, EightthCube, SixteenthCube, ThirtyTwoCube, SixtyFourcube, OneTwentyEightCube, TwoFourtyEightCube;
    //private void OnCollisionEnter(Collision collision)
    //{

    //    if(collision.gameObject.tag == "2")
    //    {
    //        Destroy(collision.gameObject);
    //        Vector3 spawnPos = collision.gameObject.transform.position;
    //        GameObject g = Instantiate(fourthCube, spawnPos, Quaternion.identity);

    //    }
    //    if(collision.gameObject.tag == "4")
    //    {
    //        Destroy(collision.gameObject);
    //        Vector3 spawnPos = collision.gameObject.transform.position;
    //        GameObject g = Instantiate(EightthCube, spawnPos, Quaternion.identity);
    //    }
    //    if(collision.gameObject.tag == "8")
    //    {
    //        Destroy(collision.gameObject);
    //        Vector3 spawnPos = collision.gameObject.transform.position;
    //        GameObject g = Instantiate(SixteenthCube, spawnPos, Quaternion.identity);
    //    }
    //    if(collision.gameObject.tag == "16")
    //    {
    //        Destroy(collision.gameObject);
    //        Vector3 spawnPos = collision.gameObject.transform.position;
    //        GameObject g = Instantiate(ThirtyTwoCube, spawnPos, Quaternion.identity);
    //    }
    //}
    //[SerializeField] GameObject[] objectsWithSameTag;
    bool destroyedOneObject;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("COllision detect");
    //    string tag = collision.gameObject.tag;

    //    // Find all GameObjects with the same tag as the collided GameObject
    //    objectsWithSameTag = GameObject.FindGameObjectsWithTag(tag);

    //    // If there's at least one other object with the same tag, perform actions
    //    if (objectsWithSameTag.Length > 1)
    //    {
    //        // Flag to check if we have already destroyed one object


    //        foreach (GameObject obj in objectsWithSameTag)
    //        {
    //            Debug.Log("hhhhhh = ");
    //            // Check if the current object is not the collided GameObject
    //            if (obj != collision.gameObject)
    //            {
    //                // Destroy the other GameObject with the same tag only if we haven't destroyed one yet
    //                Debug.Log("Secondd = ");
    //                if (!destroyedOneObject && obj.tag == gameObject.tag)
    //                {
    //                    Destroy(collision.gameObject);
    //                    Debug.Log("Obj tag = "+obj.tag);
    //                    Debug.Log("Gameobj tag = "+ gameObject.tag);
    //                    Debug.Log("Destroyed = "+collision.gameObject);
    //                    destroyedOneObject = true; // Set the flag to true after destroying one object
    //                    StartCoroutine(OneObjectDestroyWait());
    //                    if (obj.tag == "2")
    //                    {
    //                        GameObject game = Instantiate(fourthCube, obj.gameObject.transform.position, Quaternion.identity);
    //                        Debug.Log("2 called");
    //                        break;
    //                    }
    //                    if (obj.tag == "4")
    //                    {
    //                        Debug.Log("4 Obj tag = "+obj.tag);
    //                        GameObject game = Instantiate(EightthCube, obj.gameObject.transform.position, Quaternion.identity);
    //                        Debug.Log("4 called");
    //                        break;
    //                    }
    //                    if (obj.tag == "8")
    //                    {
    //                        Debug.Log("8 Obj tag = "+obj.tag);
    //                        GameObject game = Instantiate(SixteenthCube, obj.gameObject.transform.position, Quaternion.identity);
    //                        Debug.Log("8 called");
    //                        //Time.timeScale = 0;
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //        // If we found and destroyed an object, do further actions
    //        if (destroyedOneObject)
    //        {
    //            // Destroy the GameObject that triggered the collision
    //            //Destroy(collision.gameObject);
    //            Debug.Log("IF called");
    //            // Instantiate a new cube at the position of the last collided GameObject
    //            //Vector3 spawnPos = collision.gameObject.transform.position;
    //            //GameObject g = Instantiate(GetCubePrefabByTag(tag), spawnPos, Quaternion.identity);
    //            //Debug.Log("gameobj = " + g);
    //        }
    //    }
    //}
    //IEnumerator OneObjectDestroyWait()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    destroyedOneObject = false;
    //}
    //// Helper method to get the cube prefab based on the tag
    //bool isOn;
    //private GameObject GetCubePrefabByTag(string tag)
    //{
    //    switch (tag)
    //    {
    //        case "2":
    //            return fourthCube;
    //        case "4":
    //            return EightthCube;
    //        case "8":
    //            return SixteenthCube;
    //        case "16":
    //            return ThirtyTwoCube;
    //        case "32":
    //            return SixtyFourcube;
    //        case "64":
    //            return OneTwentyEightCube;
    //        // Add more cases as needed

    //        default:
    //            return null;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        // Check if the collided object has the same tag and hasn't been destroyed yet
        if (!destroyedOneObject && tag == gameObject.tag)
        {
            Destroy(collision.gameObject); // Destroy the collided object
            destroyedOneObject = true; // Set the flag to true after destroying one object
            StartCoroutine(OneObjectDestroyWait());

            // Instantiate the next cube at the position of the last collided GameObject
            Vector3 spawnPos = collision.gameObject.transform.position;
            InstantiateNextCube(spawnPos);
        }
    }

    void InstantiateNextCube(Vector3 spawnPosition)
    {
        switch (gameObject.tag)
        {
            case "2":
                Instantiate(fourthCube, spawnPosition, Quaternion.identity);
                break;
            case "4":
                Instantiate(EightthCube, spawnPosition, Quaternion.identity);
                break;
            case "8":
                Instantiate(SixteenthCube, spawnPosition, Quaternion.identity);
                break;
                // Add more cases as needed
        }
    }

    IEnumerator OneObjectDestroyWait()
    {
        yield return new WaitForSeconds(0.2f);
        destroyedOneObject = false;
    }


}