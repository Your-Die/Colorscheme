using System.Collections;
using System.Collections.Generic;
using Chinchillada.Foundation;
using UnityEngine;

namespace Chinchillada.Colorscheme
{
    public class ColorschemeManager : SingleInstanceBehaviour<ColorschemeManager>, IColorScheme, IColorschemeUser
    {
        [SerializeField] private ColorScheme colorScheme;
        
        public ColorScheme ColorScheme
        {
            get => colorScheme;
            set => colorScheme = value;
        }

        public int Count => this.colorScheme.Count;

        public Color this[int index] => this.colorScheme[index];

        public IEnumerator<Color> GetEnumerator() => this.colorScheme.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}