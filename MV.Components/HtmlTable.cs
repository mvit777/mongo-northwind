using Microsoft.AspNetCore.Components;

namespace MV.Components
{
    public partial class HtmlTable<TItem>
    {
        [Parameter]
        public string ? HTMLId { get; set; }

        [Parameter]
        public RenderFragment ? HeaderTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> ? RowTemplate { get; set; }

        [Parameter]
        public RenderFragment ? FooterTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem>? Items { get; set; }

        public void RefreshComponent(IReadOnlyList<TItem> items)
        {
            Items = items;
        }
    }
}