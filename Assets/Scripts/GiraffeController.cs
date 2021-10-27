using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeController : MonoBehaviour
{
    [SerializeField] Rigidbody2D lookAt;
    [SerializeField] Transform neck;
    float neckRotation;

    private void Start()
    {
        lookAt.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * 3;
        float y = Input.GetAxis("Vertical") * 1.5f;
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(x != 0 ? x : rigidbody.velocity.x, y != 0 ? y : rigidbody.velocity.y);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        if (x < -0.66f)
            transform.localScale = new Vector3(1, 1, 1);

        if (x > 0.66f)
            transform.localScale = new Vector3(-1, 1, 1);

        float headForce = Input.GetAxis("HorizontalTurn");
        if (Mathf.Abs(headForce) > 0.5f)
        {
            Vector2 force = Vector2.right * headForce * 5000f;
            lookAt.AddForce(force * Time.deltaTime);
        }
        else
        {
            lookAt.velocity /= (1 + Time.deltaTime);
        }

        Vector2 lookDirection = (lookAt.transform.position - transform.position).normalized;
        neck.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(lookDirection.x, lookDirection.y) * Mathf.Rad2Deg * -1f);
    }
}
