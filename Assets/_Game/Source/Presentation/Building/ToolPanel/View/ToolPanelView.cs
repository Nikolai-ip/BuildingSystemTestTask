using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Source.Presentation.Building.ToolPanel.View
{
    public class ToolPanelView: MonoBehaviour, IViewEnableable<ToolPanelViewData>, IViewInteractable<ToolPanelViewCallBack>
    {
        private List<ButtonView<BuildingToolCallback>> _buttons;
        [SerializeField] private GameObject _toolPanel;
        public event Action<ToolPanelViewCallBack> callback;

        public void Construct(List<ButtonView<BuildingToolCallback>> buttons)
        {
            _buttons = buttons;
            _buttons.ForEach(button=>button.callback += OnToolActionClicked);
        }

        private void OnDisable()
        {
            _buttons.ForEach(button=>button.callback -= OnToolActionClicked);

        }

        private void OnToolActionClicked(BuildingToolCallback toolSelectedCallback)
        {
            callback?.Invoke(new ToolPanelViewCallBack().OnToolSelected(toolSelectedCallback));
        }

        public void OnCloseButton()
        {
            callback?.Invoke(new ToolPanelViewCallBack().OnClose());
        }

        public void SetData(ToolPanelViewData data)
        { }

        public void Show()
        {
            _toolPanel.SetActive(true);
        }

        public void Hide()
        {
            _toolPanel.SetActive(false);
        }
    }

    public struct ToolPanelViewCallBack
    {
        public enum ActionType
        {
            Close,
            SelectTool
        }
        public BuildingToolCallback SelectedTool { get; private set; }
        public ActionType Action { get; private set; }

        public ToolPanelViewCallBack OnToolSelected(BuildingToolCallback c)
        {
            SelectedTool = c;
            Action = ActionType.SelectTool;
            return this;
        }

        public ToolPanelViewCallBack OnClose()
        {
            Action = ActionType.Close;
            return this;
        }
    }

    public struct ToolPanelViewData
    {
    }
}