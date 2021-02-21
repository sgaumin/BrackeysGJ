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
    bool isRotating;
    void Start()
    {
        parent = gameObject.transform.parent;
        isRotating = false;

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
                //rotation.eulerAngles = new Vector3(0, 90, 0);
                //parent.transform.rotation = rotation;
                if(isRotating == false)
                {
                    StartCoroutine(Rotate(0.2f, rotationAngle, rotation));
                }

                //parent.position = new Vector3(parent.position.x + 5, parent.position.y, parent.position.z);
            }

        }
    }
    IEnumerator Rotate(float duration, float rotationAngle, Quaternion objectToRotate)
    {
                Debug.Log("fqkodsfjsi");
                float startRotation = transform.eulerAngles.y;
                float endRotation = startRotation + rotationAngle;
        
            float t = 0.0f;
            //Time.timeScale = 0.2f;
            //Debug.Log("on est dans le cas ou r > 0" + parent.transform.rotation.y);
            
            while (t < duration)
            {
                isRotating = true;
                 t += Time.deltaTime;
                if(rotationAngle < 0)
                {
                float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAngle;
                yRotation += transform.eulerAngles.y;
                objectToRotate.eulerAngles = new Vector3(parent.eulerAngles.x, yRotation,
                parent.eulerAngles.z);
                parent.transform.rotation = objectToRotate;
                    //parent.transform.Rotate(Vector3.down, 0.5f);
                 
                }
/*                if(rotationAngle > 0)
                {
                float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAngle;
                yRotation -= transform.eulerAngles.y;
                objectToRotate.eulerAngles = new Vector3(parent.eulerAngles.x, yRotation,
                parent.eulerAngles.z);
                parent.transform.rotation = objectToRotate;
                //parent.transform.Rotate(Vector3.up, 0.5f);

                }*/


            //Time.timeScale = 1.0f;
            yield return null;
            }
            if(t == duration)
            {
                isRotating = false;
            }

        //yield return new WaitForSeconds(0.01f);
    }
}
