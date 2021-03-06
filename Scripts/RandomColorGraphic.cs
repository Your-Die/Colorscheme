﻿using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Chinchillada.Colorscheme
{
    public class RandomColorGraphic : ChinchilladaBehaviour
    {
        [SerializeField] private IColorScheme colorScheme;

        [SerializeField, FindComponent] private Graphic graphic;

        [SerializeField] private bool applyOnAwake;

        [Button]
        public void Apply() => this.graphic.color = this.colorScheme.ChooseRandom();

        protected override void Awake()
        {
            base.Awake();
            
            if (this.applyOnAwake) 
                this.Apply();
        }
    }
}