using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    Transform parent;
    [SerializeField]
    float rotationAngle;
    int ratsCount;
    void Start()
    {
        parent = gameObject.transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rat")
        {
            ratsCount = FindObjectOfType<LevelSetter>().Rats.Count;
            if(ratsCount > 20)
            {
                Debug.Log("collider");
                Quaternion rotation = Quaternion.identity;
                rotation.eulerAngles = new Vector3(0, 90, 0);
                //parent.transform.rotation = rotation;
                StartCoroutine(Rotate( 1.0f, rotationAngle));
                //parent.position = new Vector3(parent.position.x + 5, parent.position.y, parent.position.z);
            }

        }
    }
    IEnumerator Rotate(float duration, float rotationAngle)
    {
        /*        Debug.Log("fqkodsfjsi");
                float startRotation = transform.eulerAngles.y;
                float endRotation = startRotation + rotationAngle;*/
        
            float t = 0.0f;
            //Time.timeScale = 0.2f;
            Debug.Log("on est dans le cas ou r > 0");
            while (t < duration)
            {
                
                 t += Time.deltaTime;
                if(rotationAngle < 0)
                {
                 parent.transform.Rotate(Vector3.down, 0.5f);
                }
                if(rotationAngle > 0)
                {
                 parent.transform.Rotate(Vector3.up, 0.5f);
                }

            //float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAngle;
            //float yRotation;
            //yRotation += transform.eulerAngles.y;
            /* objectToRotate.eulerAngles = new Vector3(parent.eulerAngles.x, yRotation,
             parent.eulerAngles.z);
             parent.transform.rotation = objectToRotate;*/
            //Time.timeScale = 1.0f;
            yield return null;
            }

        yield return new WaitForSeconds(0.01f);
    }
}
