namespace Dreamteck
{
    using UnityEngine;

    internal static class EditorImages
    {
        public static Texture2D Load(string imageName)
        {
            return Resources.Load<Texture2D>($"dreamteck.utilities/Images/{imageName}");
        }
    }
}