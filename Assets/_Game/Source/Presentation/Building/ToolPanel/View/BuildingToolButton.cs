using UnityEngine;

namespace _Game.Source.Presentation.Building.ToolPanel.View
{
    public class BuildingToolButton: ButtonView<BuildingToolCallback>
    {
        [SerializeField] private BuildingToolCallback.ToolAction  _toolAction;
        protected override BuildingToolCallback GetInvokeParams()
        {
            return new BuildingToolCallback(_toolAction);
        }
    }

    public struct BuildingToolCallback
    {
        public enum ToolAction
        {
            None,
            Edit,
            LevelUp,
            Remove
        }

        public ToolAction Action { get; }

        public BuildingToolCallback(ToolAction action)
        {
            Action = action;
        }
    }
}