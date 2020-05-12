using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput.Wrapper;

using ZapUcommon.ErosTek;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public class ControllerPoller
    {
        public delegate void PanicDelegate();

        public static void Poller(X.Gamepad gamepad,
                           DeviceBase device,
                           PanicDelegate DoPanic,
                           List<RadioButton> controlmodeselections,
                           NumericUpDown stick_sensitivity,
                           NumericUpDown shoulder_sensitivity,
                           NumericUpDown shoulder_floor,
                           bool clear_to_send,
                           ref bool A_button_debounce,
                           ref bool B_button_debounce,
                           ref bool X_button_debounce,
                           ref bool Y_button_debounce)
        {
            if (gamepad == null) return;
            gamepad.Update();

            if (gamepad.X_down && !X_button_debounce)
            {
                X_button_debounce = true;
                DoPanic();
                return;
            }
            else X_button_debounce = false;

            RadioButton checked_input = controlmodeselections.FirstOrDefault(e => e.Checked);
            if (checked_input == null) return;

            if (gamepad.Y_down && !Y_button_debounce)
            {
                Y_button_debounce = true;
                int selidx = controlmodeselections.IndexOf(checked_input);
                selidx++;
                if (selidx >= controlmodeselections.Count) selidx = 0;
                checked_input = controlmodeselections[selidx];
                checked_input.Checked = true;
                return;
            }
            else if (gamepad.Y_up) Y_button_debounce = false;

            int shoulder_sensitivity_adjust = 0;
            if (gamepad.Dpad_Right_down) shoulder_sensitivity_adjust = 1;
            if (gamepad.Dpad_Left_down) shoulder_sensitivity_adjust = -1;
            if (shoulder_sensitivity_adjust != 0)
            {
                try
                {
                    shoulder_sensitivity.Value += shoulder_sensitivity_adjust;
                }
                catch (Exception) { }
            }

            int shoulder_floor_adjust = 0;
            if (gamepad.RBumper_down) shoulder_floor_adjust = 1;
            if (gamepad.LBumper_down) shoulder_floor_adjust = -1;
            if (shoulder_floor_adjust != 0)
            {
                try
                {
                    shoulder_floor.Value += shoulder_floor_adjust;
                }
                catch (Exception) { }
            }

            if (device == null || !device.IsReady || !clear_to_send) return;

            ModeCommand mode = null;

            if (gamepad.B_down && !B_button_debounce)
            {
                mode = new ModeCommand()
                {
                    Mode = (int)Intense.Mode,
                    MA = Intense.StartingMA
                };
                B_button_debounce = true;
            }
            else if (gamepad.B_up) B_button_debounce = false;

            if (gamepad.A_down && !A_button_debounce)
            {
                mode = new ModeCommand()
                {
                    Mode = (int)Waves.Mode,
                    MA = Waves.StartingMA
                };
                A_button_debounce = true;
            }
            else if (gamepad.A_up) A_button_debounce = false;

            if (mode != null)
            {
                device.SetMode(mode);
                return;
            }

            int sensitivity, floor;
            LevelsCommand level = new LevelsCommand() { Mode = (ControlMode)checked_input.Tag };
            switch (level.Mode)
            {
                case ControlMode.remote:
                    return;
                case ControlMode.absolute:
                    //TODO: need to mathematically ensure this always winds up 0 <= x <= 255
                    sensitivity = (int)shoulder_sensitivity.Value;
                    floor = (int)shoulder_floor.Value;
                    level.A = (int)Math.Sqrt((gamepad.LTrigger + floor) * sensitivity);
                    level.B = (int)Math.Sqrt((gamepad.RTrigger + floor) * sensitivity);
                    break;
                case ControlMode.relative:
                    sensitivity = (int)stick_sensitivity.Value;
                    level.A = (int)(gamepad.LStick_N.Y * sensitivity);
                    level.B = (int)(gamepad.RStick_N.Y * sensitivity);
                    break;
            }
            if (gamepad.Dpad_Up_down) level.MA = 1;
            if (gamepad.Dpad_Down_down) level.MA = -1;

            device.SetLevels(level);
        }

        private static readonly ErosTekModeData Intense = ZapUcommon.ErosTek.Constants.Modes[ModeSelect.Intense];
        private static readonly ErosTekModeData Waves = ZapUcommon.ErosTek.Constants.Modes[ModeSelect.Waves];
    }
}
