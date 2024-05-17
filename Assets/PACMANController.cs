using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PACMANController : MonoBehaviour
{
    public float speed;

    private FixedJoystick fixedJoystick;

    private Rigidbody rigidbody;


    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();

        fixedJoystick = FindObjectOfType<FixedJoystick>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movment = new Vector3(xVal, 0, yVal);
        rigidbody.velocity = movment * speed * Time.fixedDeltaTime;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
