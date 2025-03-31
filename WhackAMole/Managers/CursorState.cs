using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace WhackAMole.Managers
{
    class CursorState
    {

        private static readonly Lazy<CursorState> _cursorState = new Lazy<CursorState>(() => new CursorState());

        private CursorState() { }
        public static CursorState Instance => _cursorState.Value;

        /*static bool isPressed = false;


        public static bool GetIsCursorPressed() { return isPressed; }
        public static bool SetIsCursorPressed(bool value) { isPressed = value; return true; }
        */



        public void Update()
        {

            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();

        }

        public MouseState PreviousState { get; private set; }
        public MouseState CurrentState { get; private set; }

        public void MouseInfo()
        {

            PreviousState = new MouseState();
            CurrentState = Mouse.GetState();

        }


        /*
        pulbic bool IsLeftButtondDown(ButtonState button)
        {

            switch (button) {
            
                case button == ButtonState.Pressed:

            }

        }*/



    }
}
