using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldownTime = 3f;
    private float cooldownCounter = 0f;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
            Destroy(laser, 3f);
            cooldownCounter = 0f;
        }
    }

    void OnItemUsed(Color itemColor)
    {
        if (itemColor == Color.red)
        {
            cooldownTime -= 0.1f;
            FindObjectOfType<UIManager>().StartCoroutine(FindObjectOfType<UIManager>().ShowMessage(" + Fire Rate"));
        }
    }

}
