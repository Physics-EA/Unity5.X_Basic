

using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour
{
    public GameObject effect;


    private Vector3 rawPosition;
    private Vector3 hatPosition;
    private float maxWidth;

    // Use this for initialization
    void Start()
    {

        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);

        float hatWidth = GetComponent<Renderer>().bounds.extents.x;

        hatPosition = transform.position;

        maxWidth = moveWidth.x - hatWidth;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hatPosition = new Vector3(rawPosition.x, hatPosition.y, 0);
        hatPosition.x = Mathf.Clamp(hatPosition.x, -maxWidth, maxWidth);

        GetComponent<Rigidbody2D>().MovePosition(hatPosition);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject neweffect = (GameObject)Instantiate(effect, transform.position, effect.transform.rotation);

        neweffect.transform.parent = transform;
        Destroy(col.gameObject);
        Destroy(neweffect, 1.0f);
    }
}
