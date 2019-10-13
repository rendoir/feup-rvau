using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static bool MaskContainsLayer(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
