﻿using Constructor5.Core;
using Constructor5.UI.AutoGeneratedEditors;

namespace Constructor5.Elements.ZoneDirectors.Components
{
    [XmlSerializerExtraType]
    [HasAutoEditor]
    public class ZoneDirectorTemplateComponent : ZoneDirectorComponent
    {
        public override int ComponentDisplayOrder => 1;
        public override string ComponentLabel => "Content";

        [AutoEditorSelectableObject("ZoneDirectorTemplates")]
        public ZoneDirectorTemplate Template { get; set; } = new DefaultZoneDirectorTemplate();

        protected internal override void OnExport(ZoneDirectorExportContext context) => Template.OnExport(context);
    }
}