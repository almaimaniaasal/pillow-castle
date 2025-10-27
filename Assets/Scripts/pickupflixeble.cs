using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUpFlexible : MonoBehaviour
{
    public Transform holdpoint; // مكان اليد
    private GameObject heldObject; // العنصر اللي ماسكه اللاعب
    public float pickUpRange = 2f; // المسافة القصوى للالتقاط

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                // إيجاد كل العناصر القابلة للالتقاط
                GameObject[] pickables = GameObject.FindGameObjectsWithTag("mmm");
                GameObject closest = null;
                float minDistance = Mathf.Infinity;

                foreach (GameObject obj in pickables)
                {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    if (distance <= pickUpRange && distance < minDistance)
                    {
                        minDistance = distance;
                        closest = obj;
                    }
                }

                // إذا وجدنا أقرب عنصر، نمسكه
                if (closest != null)
                {
                    heldObject = closest;

                    Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                        rb.bodyType = RigidbodyType2D.Kinematic;

                    // منع تصادم العنصر مع اللاعب أثناء الإمساك
                    Physics2D.IgnoreCollision(heldObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);

                    heldObject.transform.position = holdpoint.position;
                    heldObject.transform.parent = holdpoint;
                }
            }
            else
            {
                // إعادة تصادم العنصر مع اللاعب عند الإفلات
                Physics2D.IgnoreCollision(heldObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);

                Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.bodyType = RigidbodyType2D.Dynamic;

                heldObject.transform.parent = null;
                heldObject = null;
            }
        }

        // متابعة حركة العنصر مع اليد
        if (heldObject != null)
        {
            heldObject.transform.position = holdpoint.position;
        }
    }
}



    


