using System.Collections.Generic;
using UnityEngine;

public class MAgictower : MonoBehaviour
{
   public List<GameObject> slots = new List<GameObject>();
    public GameObject flamePreFab;

    int currentSlotIndex = 0;

    public void SpawnFalameInSlot()
    {
        GameObject newFlame = Instantiate(flamePreFab, slots[currentSlotIndex].transform);

    }
}
