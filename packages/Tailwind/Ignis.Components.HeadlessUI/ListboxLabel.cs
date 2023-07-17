﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ignis.Components.HeadlessUI;

public sealed class ListboxLabel<TValue> : IgnisDynamicComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] public IListbox<TValue> Listbox { get; set; } = null!;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object?>? Attributes { get; set; }

    public ListboxLabel()
    {
        AsElement = "label";
    }

    protected override void OnInitialized()
    {
        if (Listbox == null)
        {
            throw new InvalidOperationException("ListboxLabel must be used inside a Listbox.");
        }

        Listbox.SetLabel(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenAs(0, this);
        builder.AddAttribute(1, "id", Listbox.Id + "-label");
        builder.AddAttribute(2, "onclick", EventCallback.Factory.Create(this, Listbox.FocusAsync));
        builder.AddMultipleAttributes(3, Attributes!);

        builder.AddChildContentFor(4, this, ChildContent);

        builder.CloseAs(this);
    }
}