﻿using Ignis.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ignis.Components.HeadlessUI;

public sealed class DialogPanel : IgnisRigidComponentBase, IDynamicParentComponent
{
    private Type? _asComponent;
    private string? _asElement;

    /// <inheritdoc />
    [Parameter]
    public string? AsElement
    {
        get => _asElement;
        set
        {
            _asElement = value;
            _asComponent = null;
        }
    }

    /// <inheritdoc />
    [Parameter]
    public Type? AsComponent
    {
        get => _asComponent;
        set
        {
            _asComponent = value;
            _asElement = null;
        }
    }

    [CascadingParameter] public IDialog Dialog { get; set; }

    /// <inheritdoc />
    [Parameter]
    public RenderFragment<IDynamicComponent>? _ { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IEnumerable<KeyValuePair<string, object?>>? AdditionalAttributes { get; set; }

    /// <inheritdoc />
    public ElementReference? Element { get; set; }

    /// <inheritdoc />
    public object? Component { get; set; }

    /// <inheritdoc />
    public IEnumerable<KeyValuePair<string, object?>>? Attributes => AdditionalAttributes;

    public DialogPanel()
    {
        AsElement = "div";
    }

    /// <inheritdoc />
    protected override void OnRender()
    {
        if (Dialog == null)
        {
            throw new InvalidOperationException(
                $"{nameof(DialogPanel)} must be used inside a {nameof(HeadlessUI.Dialog)}.");
        }
    }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenAs(0, this);
        builder.AddMultipleAttributes(1, Attributes!);
        // ReSharper disable once VariableHidesOuterVariable
        builder.AddContentFor(2, this, builder =>
        {
            builder.OpenComponent<FocusDetector>(3);
            builder.AddAttribute(4, nameof(FocusDetector.Id), Dialog.Id);
            builder.AddAttribute(5, nameof(FocusDetector.Strict), false);
            builder.AddAttribute(6, nameof(FocusDetector.OnBlur), EventCallback.Factory.Create(this, Dialog.Close));
            // ReSharper disable once VariableHidesOuterVariable
            builder.AddAttribute(7, nameof(FocusDetector.ChildContent),
                this.GetChildContent<IDynamicComponent, DialogPanel>(ChildContent));

            builder.CloseComponent();
        });

        builder.CloseAs(this);
    }
}