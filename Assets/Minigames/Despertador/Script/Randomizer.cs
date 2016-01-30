using UnityEngine;
using System.Collections;

public class Randomizer
{
    public static void Randomize<T>(T[] items)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = Random.Range(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
