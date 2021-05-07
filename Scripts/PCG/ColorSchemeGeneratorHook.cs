namespace Chinchillada.Colorscheme
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class ColorSchemeGeneratorHook : ChinchilladaBehaviour
    {
        [SerializeField, FindComponent] private IGenerator<ColorScheme> generator;

        [SerializeField] private List<IColorschemeUser> users = new List<IColorschemeUser>();

        public void Register(IColorschemeUser user) => this.users.Add(user);

        public void Deregister(IColorschemeUser user) => this.users.Remove(user);

        private void CleanUsers()
        {
            for (var i = this.users.Count - 1; i >= 0; i--)
            {
                if (this.users[i] != null)
                    continue;

                var lastIndex = this.users.Count - 1;

                this.users[i] = this.users[lastIndex];
                this.users.RemoveAt(lastIndex);
            }
        }

        private void FindUsers()
        {
            var newUsers = this.GetComponentsInChildren<IColorschemeUser>();
            foreach (var user in newUsers)
            {
                if (!this.users.Contains(user)) this.users.Add(user);
            }
        }

        private void OnEnable()
        {
            this.CleanUsers();
            this.FindUsers();

            if (this.generator != null) this.generator.Generated += this.UpdateColorScheme;
        }

        private void OnDisable() => this.generator.Generated -= this.UpdateColorScheme;

        private void UpdateColorScheme(ColorScheme colorScheme)
        {
            foreach (var user in this.users.Where(user => user != null))
                user.ColorScheme = colorScheme;
        }
    }
}