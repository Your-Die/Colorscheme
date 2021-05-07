using System;
using Chinchillada.Generation;
using UnityEngine;

namespace Chinchillada.Colorscheme
{
    [Serializable]
    public class MonochromeSchemeGenerator : GeneratorBase<ColorScheme>
    {
        [SerializeField] private int colorCount = 3;

        [SerializeField] private ColorGenerator colorGenerator;

        protected override ColorScheme GenerateInternal()
        {
            var hue = HSVColor.RandomHue();
            return this.Generate(hue);
        }

        public ColorScheme Generate(float hue, IRNG random = null)
        {
            random ??= new UnityRandom();
            return this.GenerateMonochromeScheme(hue, random);
        }

        public ColorScheme GenerateMonochromeScheme(float hue, IRNG random)
        {
            var colors = new HSVColor[this.colorCount];

            for (var index = 0; index < this.colorCount; index++)
            {
                var value = this.colorGenerator.ValueRange.RangeLerp((float) index / this.colorCount);
                colors[index] = this.colorGenerator.Generate(hue, value, random);
            }

            return new ColorScheme(colors);
        }
    }
}