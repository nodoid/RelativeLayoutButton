using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;

namespace RelativeLayoutButton
{
    public class RelativeLayoutButton : RelativeLayout
    {
        public RelativeLayoutButton(Context context, int id)
            : base(context)
        {
            if (!(context is Activity))
                return;

            var v = ((Activity)context).FindViewById(id);

            if (!(v is RelativeLayout))
                return;

            var layout = (RelativeLayout)v;
            var layparams = layout.LayoutParameters;
            this.LayoutParameters = layparams;
            var btn = new Button(context);
            this.SetBackgroundDrawable(btn.Background);
            while (layout.ChildCount > 0)
            {
                var vchild = layout.GetChildAt(0);
                layout.RemoveViewAt(0);
                this.AddView(vchild);
                if (vchild is TextView)
                    ((TextView)vchild).SetTextColor(btn.TextColors);
                vchild.Clickable = vchild.Focusable = true;
                vchild.FocusableInTouchMode = false;

                var vp = (ViewGroup)layout.Parent;
                if (vp != null)
                {
                    var index = vp.IndexOfChild(layout);
                    vp.RemoveView(layout);
                    vp.AddView(this, index);
                }
                this.Id = id;
            }
        }

        public void SetText(int id, string text)
        {
            View v = FindViewById(id);
            if (v != null && v is TextView)
                ((TextView)v).Text = text;
        }

        public void SetImageDrawable(int id, Drawable drawable)
        {
            View v = FindViewById(id);
            if (v != null && v is ImageView)
                ((ImageView)v).SetImageDrawable(drawable);
        }

        public void SetImageResource(int id, int resourceid)
        {
            View v = FindViewById(id);
            if (v != null && v is ImageView)
                ((ImageView)v).SetImageResource(resourceid);
        }
    }
}

