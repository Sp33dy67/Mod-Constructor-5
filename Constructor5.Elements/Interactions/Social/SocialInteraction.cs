﻿using Constructor5.Base.ComponentSystem;
using Constructor5.Base.CustomTuning;
using Constructor5.Base.ElementSystem;
using Constructor5.Base.Export;
using Constructor5.Base.ExportSystem.Tuning.Utilities;
using Constructor5.Core;
using Constructor5.Elements.Interactions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructor5.Elements.Interactions.Social
{
    [ElementTypeData("Social Interaction", true, ElementTypes = new[] { typeof(SocialInteraction) }, IsRootType = true)]
    public class SocialInteraction : InteractionElement, IExportableElement, ISupportsCustomTuning
    {
        public CustomTuningInfo CustomTuning { get; set; } = new CustomTuningInfo();

        void IExportableElement.OnExport()
        {
            var tuning = ElementTuning.Create(this);
            tuning.Class = "SocialMixerInteraction";
            tuning.InstanceType = "interaction";
            tuning.Module = "interactions.social.social_mixer_interaction";

            var context = new SocialInteractionExportContext()
            {
                Element = this,
                Tuning = tuning
            };

            foreach (var component in Components)
            {
                component.OnExport(context);
            }

            CustomTuningExporter.Export(tuning, CustomTuning);

            TuningExport.AddToQueue(tuning);
        }

        protected override void OnElementCreatedOrLoaded()
        {
            base.OnElementCreatedOrLoaded();
            foreach (var type in Reflection.GetTypesWithAttribute<SocialInteractionComponentAttribute>(false))
            {
                AddComponent(type);
            }
        }
    }
}