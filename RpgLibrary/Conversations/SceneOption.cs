using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Conversations
{
    public enum ActionType
    {
        Talk,
        End,
        Change,
        Quest,
        Buy,
        Sell
    }

    public class SceneAction
    {
        public ActionType Action { get; set; }
        public string Parameter { get; set; }
    }

    public class SceneOption
    {
        public string OptionText { get; set; }
        public string OptionScene { get; set; }
        public SceneAction OptionAction { get; set; }

        public SceneOption(string text, string scene, SceneAction action)
        {
            OptionText = text;
            OptionScene = scene;
            OptionAction = action;
        }
    }
}
