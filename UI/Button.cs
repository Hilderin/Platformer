using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    public class Button : GameObject, IMouseEventHandler
    {
        private TextureRender _upRenderer;
        private TextureRender _overRenderer;
        private TextureRender _downRenderer;
        private TextRender _textRender;

        [JsonIgnore]
        public Action OnClick;

        /// <summary>
        /// Text of the button
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Button()
        {
            //Default size...
            this.Width = 100;
            this.Height = 20;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Button(string text, Rectangle bounds, Action onClick)
        {
            Text = text;
            this.Bounds = bounds;
            OnClick = onClick;
        }

        /// <summary>
        /// Load
        /// </summary>
        public override void Load()
        {
            _upRenderer = Add(new TextureRender("button_up", this.Bounds));
            _overRenderer = Add(new TextureRender("button_over", this.Bounds));
            _overRenderer.Hide();
            _downRenderer = Add(new TextureRender("button_down", this.Bounds));
            _downRenderer.Hide();


            _textRender = Add(new TextRender(Text, "fonts\\Roboto-Bold", 12, this.Bounds, Color.White, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));


        }


        /// <summary>
        /// Handle mouse event...
        /// </summary>
        public void HandleMouseEvent(MouseAction action)
        {
            if (action == MouseAction.Enter || action == MouseAction.LeftButtonUp)
            {
                _upRenderer.Visible = false;
                _downRenderer.Visible = false;
                _overRenderer.Visible = true;
            }
            else if (action == MouseAction.Leave)
            {
                _upRenderer.Visible = true;
                _downRenderer.Visible = false;
                _overRenderer.Visible = false;
            }
            else if (action == MouseAction.LeftButtonDown)
            {
                _upRenderer.Visible = false;
                _downRenderer.Visible = true;
                _overRenderer.Visible = false;
            }

            //When pressed down... the text needs to move down also...
            if (_downRenderer.Visible)
            {
                _textRender.Y = this.Bounds.Y + 3;
            }
            else
            {
                _textRender.Y = this.Bounds.Y;
            }


            if (action == MouseAction.LeftButtonClicked)
            {
                //Clicked!
                InvokeOnClick();
            }


        }

        /// <summary>
        /// Invoke the click...
        /// </summary>
        public void InvokeOnClick()
        {
            //We have an onclick set??
            if (OnClick != null)
            {
                OnClick();
            }
            else
            {
                //We will try to find the method...                
                GameObject parent = this.Parent;
                if (parent != null && parent is GameContentContainer)
                    parent = parent.Parent;
                if (parent != null)
                {
                    MethodInfo method = parent.GetType().GetMethod(this.Name + "_OnClick");
                    if (method != null)
                        method.Invoke(parent, null);
                }
            }
        }

    }
}
