using UnityEngine;
using DG.Tweening;
public class CubeCollision : MonoBehaviour
{
    public GameObject prefab2, prefab4, prefab8, prefab16, prefab32, prefab64, prefab128, prefab256, prefab512, prefab1024, prefab2048, prefab4096;
    [SerializeField] GameObject parent;
    private bool isProcessingCollision = false;

    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Spawnner");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "over")
        {

        }
        if (collision.gameObject.tag == gameObject.tag)
        {
            GameObject newGameObject = null;

            if (gameObject.GetComponent<Bard>().CubeID > collision.gameObject.GetComponent<Bard>().CubeID)
            {
                Destroy(collision.gameObject);

                switch (gameObject.tag)
                {
                    case "2":
                        newGameObject = Instantiate(prefab4, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "4":
                        newGameObject = Instantiate(prefab8, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "8":
                        newGameObject = Instantiate(prefab16, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "16":
                        newGameObject = Instantiate(prefab32, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "32":
                        newGameObject = Instantiate(prefab64, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "64":
                        newGameObject = Instantiate(prefab128, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "128":
                        newGameObject = Instantiate(prefab256, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "256":
                        newGameObject = Instantiate(prefab512, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "512":
                        newGameObject = Instantiate(prefab1024, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "1024":
                        newGameObject = Instantiate(prefab2048, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "2048":
                        newGameObject = Instantiate(prefab4096, collision.gameObject.transform.position, Quaternion.identity, parent.transform);
                        break;
                    case "4096":
                        Debug.Log("Game Complete");
                        break;
                    default:
                        break;
                }
                Sequence mySeq = DOTween.Sequence();
                mySeq.Append(newGameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.7f).SetEase(Ease.InOutElastic));
                mySeq.Append(newGameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.7f));
                
                if (newGameObject != null)
                {
                    newGameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 350);
                    newGameObject.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 30);
                    Debug.Log("Called");
                }
            }

            Destroy(gameObject);
        }
    }

}
