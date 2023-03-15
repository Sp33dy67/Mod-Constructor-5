﻿using Constructor5.Base.ElementSystem;
using Constructor5.Core;
using Constructor5.UI.AutoGeneratedEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor5.SituationTemplates.ActiveCareerAutonomySituation
{
    [XmlSerializerExtraType]
    public class ActiveCareerAutonomySituationJobItem : ReferenceListItem
    {
        [AutoEditorReference("RoleState", ResetTo = 99710, ResetToLabel = "Generic", Label = "RoleState", HasPadding = false)]
        public Reference RoleState { get; set; } = new Reference(99710, "Generic");
    }
}