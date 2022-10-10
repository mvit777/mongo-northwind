using Microsoft.AspNetCore.Components;
using AKSoftware.Blazor.Utilities;

namespace MV.Components
{
    public partial class Button
    {
        /// <summary>
        /// If used in a table, HTMLId might identify the row something like @rowId_ButtonEdit
        /// </summary>
        [Parameter]
        public virtual string HTMLId { get; set; }
        [Parameter]
        public virtual string HTMLCssClass { get; set; } = "btn-primary";
        [Parameter]
        public virtual string Label { get; set; }
        [Parameter]
        public virtual string Icon { get; set; }
        [Parameter]
        public virtual string ClickEventName { get; set; }
        [Parameter]
        public virtual bool PreventDefault { get; set; } = true;

        public virtual void SendMessage()
        {
            try
            {
                string valueToSend = HTMLId;
                MessagingCenter.Send(this, ClickEventName, valueToSend);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.InnerException + " " + ex.StackTrace);
            }

        }

    }
}
