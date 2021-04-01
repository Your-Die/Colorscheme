using System.Linq;
using Chinchillada.Distributions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Chinchillada.Colorscheme
{
    public class ColorSchemeDistribution : SerializedMonoBehaviour, IDistribution<int>, IDistribution<Color>, IColorschemeUser
    {
        [SerializeField] private ColorScheme colorScheme;

        private IDistribution<int> distribution;

        public ColorScheme ColorScheme
        {
            get => colorScheme;
            set
            {
                colorScheme = value;
                BuildDistribution();
            }
        }

        int IDistribution<int>.Sample(IRNG random)
        {
            return this.distribution.Sample(random);
        }

        Color IDistribution<Color>.Sample(IRNG random)
        {
            var index = this.distribution.Sample(random);
            return this.colorScheme[index];
        }
        
        private void BuildDistribution() => this.distribution = this.colorScheme.ToList().IndexDistribution();

        private void Start() => this.BuildDistribution();
    }
}