﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Ignis.Components.Web;

public sealed class ScrollDetector : IgnisComponentBase
{
    [Parameter] public EventCallback<ScrollEventArgs> OnScroll { get; set; }

    // ReSharper disable once InconsistentNaming
    [Inject] public IJSRuntime JSRuntime { get; set; } = null!;

    [JSInvokable]
    public async Task OnScrollAsync(int scrollX, int scrollY)
    {
        await OnScroll.InvokeAsync(new ScrollEventArgs(scrollX, scrollY));
    }

    protected override void OnInitialized()
    {
        var _ = JSRuntime.InvokeVoidAsync("Ignis.Components.Web.ScrollDetector", DotNetObjectReference.Create(this));
    }
}
