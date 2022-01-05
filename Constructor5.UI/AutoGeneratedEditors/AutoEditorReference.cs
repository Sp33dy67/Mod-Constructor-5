﻿using Constructor5.Base.ElementSystem;
using Constructor5.UI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Constructor5.UI.AutoGeneratedEditors
{
    public class AutoEditorReference : AutoEditorAttribute
    {
        public AutoEditorReference(string elementTypeName) => ElementTypeName = elementTypeName;

        public string ElementTypeName { get; set; }
        public bool HasPadding { get; set; }
        public string Label { get; set; }
        public ulong ResetTo { get; set; }
        public string ResetToLabel { get; set; }

        public override UIElement CreateControl(object obj, PropertyInfo prop)
        {
            var padding = (Thickness)Application.Current.FindResource("Constructor.BigPaddingMinusTop");

            var stackPanel = new StackPanel();
            if (HasPadding)
            {
                stackPanel.Margin = padding;
            }

            var value = (Reference)prop.GetValue(obj);

            var labelField = (Field)null;
            if (Label != null)
            {
                labelField = new Field
                {
                    LabelWidth = new GridLength(125),
                    Label = Label
                };
                stackPanel.Children.Add(labelField);
            }

            var refControl = new ReferenceControl
            {
                EditorCategory = "ElementMini",
                ElementTypeName = ElementTypeName,
                ResetTo = ResetTo,
                ResetToLabel = ResetToLabel,
                ShowCreateButton = true
            };
            refControl.Reference = value;

            if (labelField != null)
            {
                labelField.Content = refControl;
            }
            else
            {
                stackPanel.Children.Add(refControl);
            }

            return stackPanel;
        }
    }
}