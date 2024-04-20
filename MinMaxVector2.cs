namespace Bpositive
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxVector2 : MinMaxBase<Vector2>
    {
        public override Vector2 Lerp(float t) => Vector2.Lerp(_min, _max, t);
        public override float InverseLerp(Vector2 value)
        {
            float x = Mathf.InverseLerp(_min.x, _max.x, value.x);
            float y = Mathf.InverseLerp(_min.y, _max.y, value.y);
            return (x + y) * 0.5f;
        }

        public override Vector2 Random() => new Vector2(UnityEngine.Random.Range(_min.x, _max.x), UnityEngine.Random.Range(_min.y, _max.y));
    }
}