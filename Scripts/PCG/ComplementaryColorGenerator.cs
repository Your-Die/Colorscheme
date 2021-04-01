namespace Chinchillada.Colorscheme
{
    using System;
    using System.Collections.Generic;
    using Generation;
    using UnityEngine;

    [Serializable]
    public class ComplementaryColorGenerator : GeneratorBase<ColorScheme>
    {
        [SerializeField] private int colorCount;

        [SerializeField] private ColorGenerator colorGenerator;
        
        protected override ColorScheme GenerateInternal()
        {
            var baseHue  = HSVColor.RandomHue();
            var stepSize = 1 / this.colorCount;

            var colors = GenerateColors();
            return new ColorScheme(colors);

            IEnumerable<HSVColor> GenerateColors()
            {
                for (var step = 0; step < this.colorCount; step++)
                {
                    var offset = step               * stepSize;
                    var hue    = (baseHue + offset) % 1;

                    yield return this.colorGenerator.Generate(hue, this.Random);
                }
            }
        }
    }
}