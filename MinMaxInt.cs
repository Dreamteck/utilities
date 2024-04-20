namespace Bpositive
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxInt : MinMaxBase<int>
    {
        public override int Lerp(float t) => Mathf.RoundToInt(Mathf.Lerp(_min, _max, t));
        public override float InverseLerp(int value) => Mathf.RoundToInt(Mathf.InverseLerp(_min, _max, value));

        public override int Random() => UnityEngine.Random.Range(_min, _max);
    }
}