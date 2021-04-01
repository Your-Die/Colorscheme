namespace Chinchillada.Colorscheme
{
    using System;
    using Generation;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class ColorGenerator : GeneratorBase<HSVColor>
    {
        [SerializeField] [MinMaxSlider(0, 1)] private Vector2 valueRange = new Vector2(0, 1);

        [SerializeField] [MinMaxSlider(0, 1)] private Vector2 saturationRange = new Vector2(1, 1);

        public Vector2 ValueRange => this.valueRange;

        protected override HSVColor GenerateInternal()
        {
            var hue = HSVColor.RandomHue(this.Random);
            return this.Generate(hue, this.Random);
        }

        public HSVColor Generate(float hue, IRNG random)
        {
            var value = random.Range(this.valueRange);
            return this.Generate(hue, value, random);
        }

        public HSVColor Generate(float hue, float value, IRNG random)
        {
            var saturation = random.Range(this.saturationRange);

            return new HSVColor
            {
                Hue        = hue,
                Saturation = saturation,
                Value      = value
            };
        }
    }
}