using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole.Managers
{
    class GlobalContentManager
    {

        private static readonly Lazy<GlobalContentManager> _globalContentManager = new Lazy<GlobalContentManager>(() => new GlobalContentManager());

        private GlobalContentManager() { }

        public static GlobalContentManager Instance => _globalContentManager.Value;

        private ContentManager _contentManagerRef;

        public void setContentManager(ContentManager content)
        {

            _contentManagerRef = content;

        }

        public ContentManager getContentManager()
        {

            return _contentManagerRef;

        }

    }
}
