using System.Collections;
using UnityEngine;

public class FireballBehaviour : ProjectileWeaponBehaviour
{
    private FireballController fb;
    private Transform playerTransform;
    private float angle = 0;

    protected override void Start()
    {
        base.Start();
        fb = FindObjectOfType<FireballController>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        StartCoroutine(CircleAndFade(gameObject));
    }

    private IEnumerator CircleAndFade(GameObject obj)
    {
        float startTime = Time.time;
        Renderer objRenderer = obj.GetComponent<Renderer>();
        Color originalColor = objRenderer.material.color;

        while (Time.time - startTime < weaponData.DestroySelf && obj != null)
        {
            angle += weaponData.Speed * Time.deltaTime;
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * weaponData.Radius;
            Vector3 playerPosition = playerTransform.position;
            obj.transform.position = playerPosition + offset;

            float normalizedTime = (Time.time - startTime) / weaponData.DestroySelf;
            objRenderer.material.color = Color.Lerp(originalColor, Color.clear, normalizedTime);

            yield return null;
        }

        Destroy(obj);
    }
}
