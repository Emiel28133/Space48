using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    void Update()
    {
        CycleItems();
        UseItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }

    void PickUpItem(GameObject item)
    {
        Color color = item.GetComponent<Renderer>().material.color;
        Destroy(item);
        items.Add(color);
        activeItemIndex = items.Count - 1;
        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                activeItemIndex = (activeItemIndex + 1) % items.Count;
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {
            Color itemColor = items[activeItemIndex];
            items.RemoveAt(activeItemIndex);
            if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
            else
            {
                activeItemIndex = Mathf.Clamp(activeItemIndex, 0, items.Count - 1);
                itemImageHolder.color = items[activeItemIndex];
            }

            // Notify other components about the item usage
            SendMessage("OnItemUsed", itemColor, SendMessageOptions.DontRequireReceiver);
        }
    }
}
