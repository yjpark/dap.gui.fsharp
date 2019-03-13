
using System;

using Xamarin.Forms;

namespace Dap.Fabulous.Controls {
    public class TextActionCell : TextCell {
        // Binding Propertie
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, bool, ActionEnabled, true)
        public static BindableProperty ActionEnabledProperty =                                     //__SILP__
            BindableProperty.Create("ActionEnabled", typeof(bool), typeof(TextActionCell), true);  //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, string, Action, "")
        public static BindableProperty ActionProperty =                                     //__SILP__
            BindableProperty.Create("Action", typeof(string), typeof(TextActionCell), "");  //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, Color, ActionColor, Color.Black)
        public static BindableProperty ActionColorProperty =                                             //__SILP__
            BindableProperty.Create("ActionColor", typeof(Color), typeof(TextActionCell), Color.Black);  //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, Color, ActionPressedColor, Color.Gray)
        public static BindableProperty ActionPressedColorProperty =                                            //__SILP__
            BindableProperty.Create("ActionPressedColor", typeof(Color), typeof(TextActionCell), Color.Gray);  //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, Color, ActionDisabledColor, Color.Gray)
        public static BindableProperty ActionDisabledColorProperty =                                            //__SILP__
            BindableProperty.Create("ActionDisabledColor", typeof(Color), typeof(TextActionCell), Color.Gray);  //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY(TextActionCell, Color, ActionBackgroundColor, Color.White)
        public static BindableProperty ActionBackgroundColorProperty =                                             //__SILP__
            BindableProperty.Create("ActionBackgroundColor", typeof(Color), typeof(TextActionCell), Color.White);  //__SILP__

        public event EventHandler OnAction;

        public void FireOnAction () {
            OnAction?.Invoke(this, EventArgs.Empty);
        }

        // Member Properties
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, bool, ActionEnabled)
        public bool ActionEnabled {                                   //__SILP__
            get { return (bool)GetValue(ActionEnabledProperty); }     //__SILP__
            set { SetValue(ActionEnabledProperty, value); }           //__SILP__
        }                                                             //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, string, Action)
        public string Action {                                        //__SILP__
            get { return (string)GetValue(ActionProperty); }          //__SILP__
            set { SetValue(ActionProperty, value); }                  //__SILP__
        }                                                             //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, Color, ActionColor)
        public Color ActionColor {                                    //__SILP__
            get { return (Color)GetValue(ActionColorProperty); }      //__SILP__
            set { SetValue(ActionColorProperty, value); }             //__SILP__
        }                                                             //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, Color, ActionPressedColor)
        public Color ActionPressedColor {                                //__SILP__
            get { return (Color)GetValue(ActionPressedColorProperty); }  //__SILP__
            set { SetValue(ActionPressedColorProperty, value); }         //__SILP__
        }                                                                //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, Color, ActionDisabledColor)
        public Color ActionDisabledColor {                                //__SILP__
            get { return (Color)GetValue(ActionDisabledColorProperty); }  //__SILP__
            set { SetValue(ActionDisabledColorProperty, value); }         //__SILP__
        }                                                                 //__SILP__
        //SILP: FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(TextActionCell, Color, ActionBackgroundColor)
        public Color ActionBackgroundColor {                                //__SILP__
            get { return (Color)GetValue(ActionBackgroundColorProperty); }  //__SILP__
            set { SetValue(ActionBackgroundColorProperty, value); }         //__SILP__
        }                                                                   //__SILP__
    }
}
