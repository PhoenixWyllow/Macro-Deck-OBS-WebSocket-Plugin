﻿using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.OBSWebSocketPlugin.GUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.OBSWebSocketPlugin.Actions
{
    public class SetRecordingStateAction : PluginAction
    {
        public override string Name => "OBS Set recording state";

        public override string DisplayName { get; set; } = "OBS Set recording state";

        public override string Description => "Start/stop/toggle recording";

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (!String.IsNullOrWhiteSpace(this.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.Configuration);
                    switch (configurationObject["method"].ToString())
                    {
                        case "start":
                            PluginInstance.Main.OBS.StartRecording();
                            break;
                        case "stop":
                            PluginInstance.Main.OBS.StopRecording();
                            break;
                        case "toggle":
                            PluginInstance.Main.OBS.ToggleRecording();
                            break;
                    }
                }
                catch { }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new StateSelector(this, actionConfigurator);
        }
    }
}
